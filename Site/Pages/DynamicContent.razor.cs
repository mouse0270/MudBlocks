using Microsoft.AspNetCore.Components;
using Humanizer;

namespace MudBlocks.Site.Pages
{
	public partial class DynamicContent : ComponentBase
	{
		// Add your properties and methods here
		[Parameter] public string? category { get; set; } = null;
		[Parameter] public string? block { get; set; } = null;
		[Parameter] public string type { get; set; } = "Index";
		private Type? ComponentType { get; set; } = null;

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			// Initialization logic here
		}

		protected override async Task OnParametersSetAsync()
		{
			await base.OnParametersSetAsync();
			// Parameter setting logic here

			if (!string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(block))
			{
				var assembly = System.Reflection.Assembly.GetExecutingAssembly();
				var componentFullName = $"MudBlocks.Site.Blocks.{category.Dehumanize()}.{block.Dehumanize()}.{(type ?? "Index").Humanize()}";

				ComponentType = assembly.GetType(componentFullName);
			}
		}
	}
}