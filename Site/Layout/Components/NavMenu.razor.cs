using Microsoft.AspNetCore.Components;

namespace MudBlocks.Site.Layout.Components
{
	public partial class NavMenu : ComponentBase
	{
		[Parameter] public bool DrawerOpen { get; set; } = false;
	}
}