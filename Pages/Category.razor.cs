using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlocks.Services;
using Blazored.LocalStorage;
using Microsoft.JSInterop;
using MudBlocks.Models;

namespace MudBlocks.Pages {
	public partial class Category : ComponentBase {
		[Parameter] public string CategoryName { get; set; } = default!;
		[Inject] public BlockService Blocks { get; set; } = default!;

		public List<MudBlocks.Models.Block> Categories { get; set; } = new List<MudBlocks.Models.Block>();

		protected override async Task OnInitializedAsync() {
			// Get List of Categories from Blocks
			Categories = Blocks.Blocks.Where(b => b.Category.ToLower() == CategoryName.ToLower()).ToList();

			// Update Category Name
			if (Categories.Any()) CategoryName = Categories.First().Category;

			// Remove Code
			Blocks.ShowCode = false;
			Blocks.Code = "";
			
			// Initialization logic here
			await base.OnInitializedAsync();
		}
	}
}