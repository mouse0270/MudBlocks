using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace MudBlocks.Site.Layout {
	public partial class MainLayout : LayoutComponentBase {
		// Add your properties and methods here
		[Inject] public NavigationManager NavigationManager { get; set; } = default!;
		[Inject] public MudBlazor.ISnackbar Snackbar { get; set; } = default!;
		[Inject] public MudBlocks.Site.Services.Database Database { get; set; } = default!;
		[Inject] public MudBlocks.Site.Services.ThemeService Theme { get; set; } = default!;
		[Inject] public MudBlocks.Site.Services.BreadCrumbService Breadcrumbs { get; set; } = default!;
		[Inject] public MudBlocks.Site.Services.BlockService BlockService { get; set; } = default!;
		[Inject] public Microsoft.JSInterop.IJSRuntime JSRuntime { get; set; } = default!;
		private DotNetObjectReference<MainLayout>? _dotNetRef;
		private string DisplayMode { get; set; } = "Desktop";
		private bool ViewCode { get; set; } = false;
		private List<Services.Database.Block>? Blocks { get; set; } = null;

		protected override async Task OnInitializedAsync() {
			await base.OnInitializedAsync();
			// Initialization logic here

			 _dotNetRef = DotNetObjectReference.Create(this);

			// Get the blocks from the database
			Blocks = await Database.Get();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender) {
			await base.OnAfterRenderAsync(firstRender);
			// After render logic here

			if (firstRender) {
				await JSRuntime.InvokeVoidAsync("registerBlazorComponent", _dotNetRef);
				Theme.IsDarkMode = await JSRuntime.InvokeAsync<string>("getStorage", "isDarkMode") == "true";
				Theme.Color = await JSRuntime.InvokeAsync<string>("getStorage", "themeColor") ?? "DeepPurple";
				Theme.Mode = await JSRuntime.InvokeAsync<string>("getStorage", "themeMode") ?? "Monochromatic";
				Theme.Font = await JSRuntime.InvokeAsync<string>("getStorage", "themeFont") ?? "Roboto";
				string fontUrl = Theme.Fonts[Theme.Font].FontUrl;

				// Listen for theme changes
				// When the theme changes, we need to update the theme options
				Theme.OnThemeChanged += async (isDarkMode, themeColor, themeMode, themeFont) => {
					string fontUrl = Theme.Fonts[themeFont].FontUrl;
					await JSRuntime.InvokeVoidAsync("setThemeOptions", isDarkMode, themeColor, themeMode, themeFont, fontUrl);
					StateHasChanged();
				};

				// Listen for block changes
				// When the block changes, we need to re-render the page
				BlockService.OnBlockChanged += async (code, displayMode) => {
					Console.WriteLine($"Block Changed: {BlockService.Code.Length} | {code.Length} | {displayMode}");
					await Task.Yield();
					StateHasChanged();
				};

				// Listen for location changes
				// When the location changes, we need to clear the block service
				NavigationManager.LocationChanged += async (sender, args) => {
					BlockService.Code = "";
					BlockService.DisplayMode = "Desktop";
					BlockService.ViewCode = false;
					await Task.Yield();
					StateHasChanged();
				};
				
				await JSRuntime.InvokeVoidAsync("setThemeOptions", Theme.IsDarkMode, Theme.Color, Theme.Mode, Theme.Font, fontUrl);
			}
			if (firstRender) StateHasChanged();
		}

		protected override async Task OnParametersSetAsync() {
			await base.OnParametersSetAsync();
			// Parameter setting logic here
		}

		private void SetTheme(string color, string mode) {
			Theme.Color = color;
			Theme.Mode = mode;
		}

		private void SetFont(string font) {
			Theme.Font = font;
		}

		private async void CopyToClipboard() {
			await JSRuntime.InvokeVoidAsync("CopyToClipBoard", BlockService.Code);
			Snackbar.Configuration.PositionClass = MudBlazor.Defaults.Classes.Position.TopCenter;
			Snackbar.Add("Copied!", MudBlazor.Severity.Info, config => {});
		}

		[JSInvokable] 
		public Task SetThemeOptions(bool isDarkMode, string themeColor, string themeMode, string themeFont) {
			bool hasChanged = isDarkMode != Theme.IsDarkMode || themeColor != Theme.Color || themeMode != Theme.Mode || themeFont != Theme.Font;
			if (isDarkMode != Theme.IsDarkMode) Theme.IsDarkMode = isDarkMode;
			if (themeColor != Theme.Color) Theme.Color = themeColor;
			if (themeMode != Theme.Mode) Theme.Mode = themeMode;
			if (themeFont != Theme.Font) Theme.Font = themeFont;
			if (hasChanged) StateHasChanged();
        	return Task.CompletedTask;
    	}

		 public void Dispose() {
			Theme.OnThemeChanged -= null;
		}
	}
}