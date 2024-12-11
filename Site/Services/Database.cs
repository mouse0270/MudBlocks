using System.Net.Http.Json;

namespace MudBlocks.Site.Services;

public class Database {
	public class Block {

		public string Namespace { get; set; } = String.Empty;
		public List<string> AltUrls { get; set; } = [];
		public string? Title { get; set; } = String.Empty;
		public string? Description { get; set; } = String.Empty;
		public List<string>? Keywords { get; set; } = [];
		public List<BlockService.Author>? Authors { get; set; } = [];
		public List<string>? Tags { get; set; } = [];
		public DateOnly? Created { get; set; } = null;
		public DateOnly? Updated { get; set; } = null;
	}

	private readonly HttpClient _httpClient;

	private List<Block>? BlocksCache { get; set; } = null;

	public Database(HttpClient httpClient) {
        _httpClient = httpClient;
    }

	public static List<Block> Get() {
		return StaticData.Blocks;
    }
}