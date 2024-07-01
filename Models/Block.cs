namespace MudBlocks.Models;
public class Block {
	public string Url { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Image { get; set; }
	public List<Author> Authors { get; set; }
	public string Category { get; set; }
	public List<string> Tags { get; set; }
}