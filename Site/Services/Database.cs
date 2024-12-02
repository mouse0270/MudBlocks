using System.Net.Http.Json;

namespace MudBlocks.Site.Services;

public class Database {
	public class Block {

		public string Namespace { get; set; } = String.Empty;
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

	public async Task<List<Database.Block>> Get() {
		if (BlocksCache == null || BlocksCache.Count() == 0) BlocksCache = await _httpClient.GetFromJsonAsync<List<Database.Block>>("assets/db.json") ?? new List<Database.Block>();
		
		return BlocksCache;
    }

	public async Task Refresh() {
		BlocksCache = await _httpClient.GetFromJsonAsync<List<Database.Block>>("assets/db.json") ?? new List<Database.Block>();
	}
}