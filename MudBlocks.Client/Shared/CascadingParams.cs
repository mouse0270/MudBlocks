
    namespace MudBlocks.Client.Shared;
	public class CascadingParams {
        public class Author {
            public string Name { get; set; } = String.Empty;
            public string Image { get; set; } = String.Empty;
            public string Url { get; set; } = String.Empty;
        }

        public bool ShowCode { get; set; } = false;
        public string CodeToCopy { get; set; } = String.Empty;
        public List<Author> Authors { get; set; } = new List<Author>();
    }