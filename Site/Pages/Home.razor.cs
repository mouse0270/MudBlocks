using Microsoft.AspNetCore.Components;
using Humanizer;

namespace MudBlocks.Site.Pages
{
	public partial class Home : ComponentBase
	{
		[Inject] private Services.ThemeService Theme { get; set; } = default!;
		[Inject] private Services.BreadCrumbService BreadCrumbService { get; set; } = default!;
		[Inject] private Services.Database Database { get; set; } = default!;
		private List<Services.Database.Block>? Blocks { get; set; } = null;
		private List<Services.Database.Block> ListBlocks { get; set; } = new List<Services.Database.Block>();

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			// Initialization logic here

			BreadCrumbService.Clear();

			// Get the blocks from the database
			Blocks = await Database.Get();
			if (Blocks != null) ListBlocks = Blocks.GroupBy(b => b.Namespace.Split(".")[0]).Select(g => g.OrderBy(_ => Guid.NewGuid()).First()).ToList() ?? new List<Services.Database.Block>();

			// Listen for theme changes
			// When the theme changes, we need to update the theme options
			Theme.OnThemeChanged += async (isDarkMode, themeColor, themeMode, themeFont) => {
				StateHasChanged();
			};
		}
	}
}