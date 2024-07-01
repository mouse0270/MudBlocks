using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlocks.Services;
using Blazored.LocalStorage;
using Microsoft.JSInterop;
using MudBlocks.Models;

namespace MudBlocks.Layout {
	public partial class NavMenu : ComponentBase {
		[Inject] public BlockService Blocks { get; set; } = default!;

		public List<string> Categories { get; set; } = new List<string>();

		protected override async Task OnInitializedAsync() {
			// Get List of Categories from Blocks
			Categories = Blocks.Blocks.Select(b => b.Category).Distinct().ToList();
			
			// Initialization logic here
			await base.OnInitializedAsync();
		}
	}
}