using MudBlocks.Models;

namespace MudBlocks.Services {
	public class BlockService {
		public bool ShowCode { get; set; } = false;

		private string _code { get; set; } = "";
		public string Code {
			get { return _code; }
			set {
				_code = value;
				OnMajorUpdateOccured();
			}
		}

		public event EventHandler MajorUpdateOccured;

		private void OnMajorUpdateOccured() => MajorUpdateOccured?.Invoke(this, EventArgs.Empty);

		public List<MudBlocks.Models.Block> Blocks { get; set; } = new List<Block>() {
			new Block {
				Url = "/blocks/blog/1",
				Name = "Blog Cards",
				Description = string.Empty,
				Image = "/images/blocks/blog/001.jpg",
				Authors = new List<Author> {
					new Author { Name = "Mouse0270", Url = "https://github.com/mouse0270", Image = "https://avatars.githubusercontent.com/u/564874?v=4" },
					new Author { Name = "Tailblocks", Url = "https://github.com/mertJF/tailblocks" }
				},
				Category = "Blog",
				Tags = new List<string> { "Blog", "MudCard" },
			}, 
			new Block {
				Url = "/blocks/blog/2",
				Name = "Blog Cards",
				Description = string.Empty,
				Image = "/images/blocks/blog/002.jpg",
				Authors = new List<Author> {
					new Author { Name = "Mouse0270", Url = "https://github.com/mouse0270", Image = "https://avatars.githubusercontent.com/u/564874?v=4" },
					new Author { Name = "Tailblocks", Url = "https://github.com/mertJF/tailblocks" }
				},
				Category = "Blog",
				Tags = new List<string> { "Blog", "MudCard" },
			},
			new Block {
				Url = "/blocks/blog/3",
				Name = "Blog Cards",
				Description = string.Empty,
				Image = "/images/blocks/blog/003.jpg",
				Authors = new List<Author> {
					new Author { Name = "Mouse0270", Url = "https://github.com/mouse0270", Image = "https://avatars.githubusercontent.com/u/564874?v=4" },
					new Author { Name = "Tailblocks", Url = "https://github.com/mertJF/tailblocks" }
				},
				Category = "Blog",
				Tags = new List<string> { "Blog", "MudCard", "MudAvatar" },
			},
			new Block {
				Url = "/blocks/blog/4",
				Name = "Blog Cards",
				Description = string.Empty,
				Image = "/images/blocks/blog/004.jpg",
				Authors = new List<Author> {
					new Author { Name = "Mouse0270", Url = "https://github.com/mouse0270", Image = "https://avatars.githubusercontent.com/u/564874?v=4" },
					new Author { Name = "Tailblocks", Url = "https://github.com/mertJF/tailblocks" }
				},
				Category = "Blog",
				Tags = new List<string> { "Blog" },
			},
			new Block {
				Url = "/blocks/contact/1",
				Name = "Contact",
				Description = string.Empty,
				Image = "/images/blocks/contact/001.jpg",
				Authors = new List<Author> {
					new Author { Name = "Mouse0270", Url = "https://github.com/mouse0270", Image = "https://avatars.githubusercontent.com/u/564874?v=4" },
					new Author { Name = "Tailblocks", Url = "https://github.com/mertJF/tailblocks" }
				},
				Category = "Contact",
				Tags = new List<string> { "Contact", "MudCard", "MudTextField" },
			},
		};
	}
}