using MudBlocks.Models;

namespace MudBlocks.Services {
	public class BlockService {
		public bool ShowCode { get; set; } = false;
		public string Code { get; set; } = "";
		public List<Author> Authors { get; set; } = new List<Author>();
	}
}