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
		private string? category { get; set; } = null;
		private string? block { get; set; } = null;
		private string type { get; set; } = "Index";
		private List<string> ThemeOptions { get; set; } = new List<string>();

		private List<Services.Database.Block>? Blocks { get; set; } = null;
		private Type? ComponentType { get; set; } = null;
		
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
			Blocks = await Database.Get();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender) {
			await base.OnAfterRenderAsync(firstRender);
			// After render logic here
		}

		protected override async Task OnParametersSetAsync() {
			await base.OnParametersSetAsync();
			// Parameter setting logic here

			// If url is `/random` then select a random Block from the database
			type = NavigationManager.ToBaseRelativePath(NavigationManager.Uri).Split('/').First().Humanize();
			if ((type.ToLower() == "random" || type.ToLower() == "r") && (Blocks ?? new List<Services.Database.Block>()).Count > 0) {
				var random = new Random();
				var randomBlock = (Blocks ?? new List<Services.Database.Block>())[random.Next(0, (Blocks ?? new List<Services.Database.Block>()).Count)];
				category = randomBlock.Namespace.Split('.').First();
				block = randomBlock.Namespace.Split('.').Last();
			}

			if (type.ToLower() == "s" || type.ToLower() == "skeleton" ) type = "Skeleton";

			// Setup Variables from Path
			if (!string.IsNullOrWhiteSpace(Path)) {
				// Split the path into segments
				var segments = Path.Split('/', StringSplitOptions.RemoveEmptyEntries);
				if (segments.Length >= 2) {
					category = segments[0];
					block = segments[1];
					ThemeOptions = segments.Skip(2).ToList();
				}
			}

			// Set the Category BreadCrumb
			if (!string.IsNullOrWhiteSpace(category)) {
				BreadCrumbService.Set(new List<MudBlazor.BreadcrumbItem> {
					new MudBlazor.BreadcrumbItem(category.Humanize(LetterCasing.Title), href: $"/category/{category}"),
				});
			}

			if (!string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(block)) {
				BreadCrumbService.Add(new MudBlazor.BreadcrumbItem(block.Humanize(LetterCasing.Title), href: $"/blocks/{category}/{block}"));

				var assembly = System.Reflection.Assembly.GetExecutingAssembly();
				var componentFullName = $"MudBlocks.Site.Blocks.{category.Dehumanize()}.{block.Dehumanize()}.{(type != "Skeleton" ? "Index" : "Skeleton")}";
				ComponentType = assembly.GetType(componentFullName);

				var url = $"https://raw.githubusercontent.com/mouse0270/MudBlocks/main/Site/Pages/Blocks/{category.Dehumanize()}/{block.Dehumanize()}/Index.razor";
				BlockService.Code = await FetchRazorFileContent(url);

				// Check if Block is in Database
				if (Blocks != null && Blocks.Count > 0) {
					var component = Blocks.FirstOrDefault(b => b.Namespace == $"{category.Dehumanize()}.{block.Dehumanize()}");
					if (component != null) {
						BlockService.Authors = component?.Authors ?? new List<Services.BlockService.Author>();
						BlockService.Tags = component?.Tags ?? new List<string>();
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
				Console.WriteLine(ex.Message);
				return "Unable to load block content.";
			}
		}
	}
}