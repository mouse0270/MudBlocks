using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlocks.Services;
using Blazored.LocalStorage;
using Microsoft.JSInterop;

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
		[Inject] public IJSRuntime JSRuntime { get; set; } = default!;
		[Inject] public NavigationManager NavigationManager { get; set; } = default!;
		[Inject] public ILocalStorageService LocalStorage { get; set; } = default!;
		[Inject] public ISnackbar Snackbar { get; set; } = default!;
		[Inject] public ThemeService Themes { get; set; } = default!;
		[Inject] public BlockService Blocks { get; set; } = default!;

		// Define Class Properties
		public MenuClass Menu { get; set; } = new MenuClass();
		public MenuClass ColorMenu { get; set; } = new MenuClass();
		public string Title { get; set; } = "MudBlocks";

		public List<MudBlocks.Models.Author> Authors = new List<MudBlocks.Models.Author>();
		public string GithubURL = string.Empty;

		protected override async Task OnInitializedAsync() {
			// if host is mudframes.cc then set title to MudFrames
			if (new Uri(NavigationManager.Uri).Host.Contains("mudframes")) Title = "MudFrames";

			// Get the theme from local storage
			Themes.Current = await LocalStorage.GetItemAsync<string>("theme") ?? "Indigo";
			Themes.IsDarkMode = (await LocalStorage.GetItemAsync<string>("darkmode") ?? "false").ToLower() == "true";

			// Watch for location changes
			NavigationManager.LocationChanged += LocationChanged;
			

			// Attaches the MajorUpdateOccured event to the LayoutServiceOnMajorUpdateOccured method
			Blocks.MajorUpdateOccured += BlocksServiceOnMajorUpdateOccured;

			SetBlockData();
			
			// Initialization logic here
			await base.OnInitializedAsync();
		}

		protected override async Task OnParametersSetAsync() {
			// Parameter setup logic here
			await base.OnParametersSetAsync();
		}

		protected override async Task OnAfterRenderAsync(bool firstRender) {
			if (firstRender) {
				Themes.IsDarkMode = await Themes.Provider.GetSystemPreference();
				await Themes.Provider.WatchSystemPreference(OnSystemPreferenceChanged);
			}

			// After render logic here
			await base.OnAfterRenderAsync(firstRender);
		}

		private Task OnSystemPreferenceChanged(bool newValue) {
			Themes.IsDarkMode = newValue;
			StateHasChanged();
			return Task.CompletedTask;
		}
	
		private async Task SetTheme(string theme) {
			await LocalStorage.SetItemAsync("theme", theme);
			Themes.Current = theme;
		}

		private async Task SetDarkMode(bool darkmode) {
			await LocalStorage.SetItemAsync("darkmode", darkmode.ToString().ToLower());
			await JSRuntime.InvokeVoidAsync("window.setHLJSStyle", darkmode.ToString().ToLower());
			Themes.IsDarkMode = darkmode;
		}

		private void LocationChanged(object sender, object e) {
			// Location change logic here
			Blocks.ShowCode = false;

			SetBlockData();

			StateHasChanged();
		}

		private void SetBlockData() {
			// Get URL without Domain
			GithubURL = new Uri(NavigationManager.Uri).PathAndQuery;
			// Get Block from query
			MudBlocks.Models.Block block = Blocks.Blocks.FirstOrDefault(b => b.Url == GithubURL);

			if (block == null) Authors = new List<MudBlocks.Models.Author>();
			else {
				 Authors = block.Authors;

				// Fix Github URL
				// - blocks/blog/1 => Blocks/Blog/001
				// - blocks/blog/2 => Blocks/Blog/002
				// - blocks/contact/1 => Blocks/Contact/001
				string[] parts = GithubURL.Split('/');
				if (parts.Length >= 3) {
					string category = parts[2].First().ToString().ToUpper() + parts[2].Substring(1);
					// Pad blockId with 0s
					string blockId = parts[3].PadLeft(3, '0');
					GithubURL = $"Blocks/{category}/{blockId}";
				}
			}
		}

		private async Task CopyCode() {
			await JSRuntime.InvokeVoidAsync("copyToClipboard", Blocks.Code);

			Snackbar.Add("Block Copied!", Severity.Info);
		}
    
    	private void BlocksServiceOnMajorUpdateOccured(object sender, EventArgs e) => StateHasChanged();

		public void Dispose() {
			// Dispose logic here
			NavigationManager.LocationChanged -= LocationChanged;
        	Blocks.MajorUpdateOccured -= BlocksServiceOnMajorUpdateOccured;
		}
	}
}