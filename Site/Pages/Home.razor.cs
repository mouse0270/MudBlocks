using Microsoft.AspNetCore.Components;
using Humanizer;
using System.Drawing;

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
			Blocks = Services.Database.Get();
			if (Blocks != null) ListBlocks = Blocks.GroupBy(b => b.Namespace.Split(".")[0]).Select(g => g.OrderBy(_ => Guid.NewGuid()).First()).ToList() ?? new List<Services.Database.Block>();

			// Listen for theme changes
			// When the theme changes, we need to update the theme options
			Theme.OnThemeChanged += (isDarkMode, themeColor, themeMode, themeFont) => {
				StateHasChanged();
			};

			await ChangeColor();
		}

		
		private MudBlazor.Color currentColor = MudBlazor.Color.Success;
		private readonly List<MudBlazor.Color> colorList = new List<MudBlazor.Color> {
			MudBlazor.Color.Success,
			MudBlazor.Color.Warning,
			MudBlazor.Color.Error,
			MudBlazor.Color.Info
		};

		private async Task ChangeColor() {
			var random = new Random();
			MudBlazor.Color randomColor = colorList[random.Next(colorList.Count)];
			if (currentColor == randomColor) {
				await ChangeColor();
			} else {
				currentColor = randomColor;
			}
			StateHasChanged();
			await Task.Delay(600);
			await ChangeColor();
		}
	}
}