using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlocks.Services;

namespace MudBlocks.Layout {
	public partial class MainLayout : LayoutComponentBase {
		/* Define a class for the menu */
		public class MenuClass {
			public bool IsOpen { get; set; } = true;
			public string Icon { get {
				return IsOpen ? Icons.Material.Outlined.ArrowBack : Icons.Material.Outlined.Menu;
			} }
			public void Toggle() => IsOpen = !IsOpen;
		}
		
		// Handle Injected Services
		[Inject] public NavigationManager NavigationManager { get; set; } = default!;
		[Inject] public ThemeService Themes { get; set; } = default!;

		// Define Class Properties
		public MenuClass Menu { get; set; } = new MenuClass();
		public string Title { get; set; } = "MudBlocks";

		protected override async Task OnInitializedAsync() {
			// if host is mudframes.cc then set title to MudFrames
			if (new Uri(NavigationManager.Uri).Host.Contains("mudframes")) Title = "MudFrames";
			
			// Initialization logic here
			await base.OnInitializedAsync();
		}

		protected override async Task OnParametersSetAsync() {
			// Parameter setup logic here
			await base.OnParametersSetAsync();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender) {
			// After render logic here
			await base.OnAfterRenderAsync(firstRender);
		}
	}
}