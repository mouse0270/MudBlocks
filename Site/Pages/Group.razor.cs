using Microsoft.AspNetCore.Components;
using Humanizer;

namespace MudBlocks.Site.Pages {
	public partial class Group : ComponentBase {
		// Add your properties and methods here
		[Parameter] public string? Path { get; set; } = null;

		[Inject] private NavigationManager NavigationManager { get; set; } = default!;
		[Inject] private Services.ThemeService Theme { get; set; } = default!;
		[Inject] private Services.BreadCrumbService BreadCrumbService { get; set; } = default!;
		[Inject] public Services.BlockService BlockService { get; set; } = default!;
		[Inject] private Services.Database Database { get; set; } = default!;
		private List<Services.Database.Block>? Blocks { get; set; } = null;
		private string? type { get; set; } = null;
		private List<string> options { get; set; } = new List<string>();
		
		protected override async Task OnInitializedAsync() {
			await base.OnInitializedAsync();
			// Initialization logic here

			// Listen for block changes
			// When the block changes, we need to re-render the page
			BlockService.OnBlockChanged += async (code, displayMode) => {
				await Task.Yield();
				StateHasChanged();
			};

			// Listen for theme changes
			// When the theme changes, we need to update the theme options
			Theme.OnThemeChanged += (isDarkMode, themeColor, themeMode, themeFont) => {
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

			if (!string.IsNullOrWhiteSpace(Path)) {
				// Split the path into segments
				var segments = Path.Split('/', StringSplitOptions.RemoveEmptyEntries);
				type = NavigationManager.ToBaseRelativePath(NavigationManager.Uri).Split('/').First().Humanize();
				if (segments.Length >= 1) {
					options = segments.ToList();
				}
			}

			// Set the Category BreadCrumb
			if (options.Count > 0 && type != null) {
				BreadCrumbService.Set(new List<MudBlazor.BreadcrumbItem> {
					new MudBlazor.BreadcrumbItem(options.First().Humanize(LetterCasing.Title), href: $"/category/{string.Join("/", options)}"),
				});
			}

			if (Blocks != null && Blocks.Count > 0 && type != null) {
				if (type.ToLower() == "category" || type.ToLower() == "categories") {
					// Get the blocks from the database
					Blocks = Blocks.Where(b => options.Any(option => b.Namespace.Split('.').First().Humanize().ToLower() == option.Humanize().ToLower())).ToList();
				}

				if (type.ToLower() == "tag" || type.ToLower() == "tags") {
					// Get the blocks from the database
					Blocks = Blocks.Where(b => b.Tags != null && options.Any(option => b.Tags.Any(tag => tag.Humanize().ToLower() == option.Humanize().ToLower()))).ToList();
				}
			}
		}
	}
}