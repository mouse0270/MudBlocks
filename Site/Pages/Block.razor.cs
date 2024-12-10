using Microsoft.AspNetCore.Components;
using Humanizer;

namespace MudBlocks.Site.Pages {
	public partial class Block : ComponentBase {
		// Add your properties and methods here
		[Parameter] public string? Path { get; set; } = null;

		[Inject] private NavigationManager NavigationManager { get; set; } = default!;
		[Inject] private Services.ThemeService Theme { get; set; } = default!;
		[Inject] private Services.BreadCrumbService BreadCrumbService { get; set; } = default!;
		[Inject] public Services.BlockService BlockService { get; set; } = default!;
		[Inject] private Services.Database Database { get; set; } = default!;
		private string blockType { get; set; } = "Index";
		private string? category { get; set; } = null;
		private string? block { get; set; } = null;
		private List<string> ThemeOptions { get; set; } = new List<string>();

		private List<Services.Database.Block>? Blocks { get; set; } = null;
		private Type? ComponentType { get; set; } = null;
		private Services.Database.Block? Component { get; set; } = null;
		
		protected override async Task OnInitializedAsync() {
			await base.OnInitializedAsync();
			// Initialization logic here

			// Listen for block changes
			// When the block changes, we need to re-render the page
			BlockService.OnBlockChanged += async (code, displayMode) => {
				await Task.Yield();
				StateHasChanged();
			};

			// Get the blocks from the database
			Blocks = Services.Database.Get();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender) {
			await base.OnAfterRenderAsync(firstRender);
			// After render logic here
		}

		protected override async Task OnParametersSetAsync() {
			await base.OnParametersSetAsync();

			// Get Base Page Path
			// :basePath/:category/:block/{:theme|:color|:font|:mode}
			string basePath = NavigationManager.ToBaseRelativePath(NavigationManager.Uri).Split('/').First().Humanize();

			// Handle the type of Block to Display
			// :s || :skeleton = Display the Skeleton of the Block
			if (basePath.ToLower() == "s" || basePath.ToLower() == "skeleton") blockType = "Skeleton";

			// Handle if basePath is `r` || `random` then select a random block
			if (basePath.ToLower() == "r" || basePath.ToLower() == "random") {
				var random = new Random();
				var randomBlock = (Blocks ?? new List<Services.Database.Block>())[random.Next(0, (Blocks ?? new List<Services.Database.Block>()).Count)];
				category = randomBlock.Namespace.Split('.').First();
				block = randomBlock.Namespace.Split('.').Last();
			}

			// Get the Category and Block from the path
			// Setup Variables from Path
			if (!string.IsNullOrWhiteSpace(Path)) {
				// Split the path into segments
				var segments = Path.Split('/', StringSplitOptions.RemoveEmptyEntries);
				if ((basePath.ToLower() == "r" || basePath.ToLower() == "random") && segments.Length >= 1) {
					// If the base path is random, then the segments are theme options
					ThemeOptions = [.. segments];
				}else if (segments.Length >= 2) {
					// Assume the first segment is the category and the second segment is the block
					category = segments[0];
					block = segments[1];
					// If there are more than 2 segments, then the rest are theme options
					if (segments.Length >= 3) ThemeOptions = segments.Skip(2).ToList();
				}
			}

			// Set the Breadcrumbs for Category
			if (!string.IsNullOrWhiteSpace(category)) {
				BreadCrumbService.Set(new List<MudBlazor.BreadcrumbItem> {
					new MudBlazor.BreadcrumbItem(category.Humanize(LetterCasing.Title), href: $"/category/{category}"),
				});
				// Set the Breadcrumbs for Block
				if (!string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(block)) {
					BreadCrumbService.Add(new MudBlazor.BreadcrumbItem(block.Humanize(LetterCasing.Title), href: $"/blocks/{category}/{block}"));
				}
			}

			if (!string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(block)) {
				// Get The Block
				if (Blocks != null && Blocks.Count > 0) {
					Component = Blocks.Find(b => b.Namespace.Equals($"{category.Dehumanize()}.{block.Dehumanize()}", StringComparison.OrdinalIgnoreCase));
					if (Component != null) {
						BlockService.Authors = Component?.Authors ?? new List<Services.BlockService.Author>();
						var url = $"https://raw.githubusercontent.com/mouse0270/MudBlocks/main/Site/Blocks/{(Component?.Namespace ?? "").Replace(".", "/")}/{(blockType != "Skeleton" ? "Index" : "Skeleton")}.razor"; 
						BlockService.Code = await FetchRazorFileContent(url);
					}else{
						//SentrySdk.CaptureMessage($"Block not found: {category}/{block}");
					}
				}
				StateHasChanged();
			}

			if (ThemeOptions.Count > 0) {
				// Inline functions to check if the theme options are valid
				bool isThemeOptionDarkLight(string themeOption) => themeOption.Equals("dark", StringComparison.OrdinalIgnoreCase) || themeOption.Equals("light", StringComparison.OrdinalIgnoreCase);
				bool isThemeOptionColor(string themeOption) => Theme.Themes.Any(t => t.Key.Equals(themeOption.Humanize(LetterCasing.Title), StringComparison.OrdinalIgnoreCase));
				bool isThemeOptionFont(string themeOption) => Theme.Fonts.Any(f => f.Key.Equals(themeOption.Humanize(LetterCasing.Title), StringComparison.OrdinalIgnoreCase));
				bool isThemeOptionMode(string themeOption) => (new string[] { "Analogous", "Monochromatic", "Triadic", "Complementary", "Tetradic" }).Contains(themeOption.Humanize(LetterCasing.Title));

				// Check if Theme Options are set and determine what they are
				bool hasThemeOptionSet = false;

				// Loop through each theme option and set the theme accordingly
				foreach(string themeOption in ThemeOptions) {
					if (string.IsNullOrWhiteSpace(themeOption)) continue;
					string option = themeOption.Humanize(LetterCasing.LowerCase).Trim().Replace(" ", "");

					if (isThemeOptionDarkLight(option) && Theme.IsDarkMode != (option.ToLower() == "dark")) {
						Theme.IsDarkMode = themeOption.ToLower() == "dark";
						hasThemeOptionSet = true;
					} 
					if (isThemeOptionColor(option) && Theme.Color != Theme.GetColorKey(option)) {
						Theme.Color = Theme.GetColorKey(option);
						hasThemeOptionSet = true;
					}
					if (isThemeOptionFont(option) && Theme.Font != Theme.GetFontKey(option)) {
						Theme.Font = Theme.GetFontKey(option);
						hasThemeOptionSet = true;
					} 
					if (isThemeOptionMode(option) && Theme.Mode != Theme.GetModeKey(option)) {
						Theme.Mode = Theme.GetModeKey(option);
						hasThemeOptionSet = true;
					}
				}

				if (hasThemeOptionSet) {
					StateHasChanged();
				}
			}
		}

		private async Task<string> FetchRazorFileContent(string url) {
			try {
				using (HttpClient httpClient = new HttpClient()) {
					var response = await httpClient.GetAsync(url);
					response.EnsureSuccessStatusCode();
					return await response.Content.ReadAsStringAsync();
				}
			} catch (Exception ex) {
				// Log the exception (ex) if necessary
				//SentrySdk.CaptureException(ex);
				return "Unable to load block content.";
			}
		}
	}
}