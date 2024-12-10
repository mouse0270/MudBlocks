namespace MudBlocks.Site.Services;

public class BlockService {
	private string _displayMode { get; set; } = "Desktop";
	private string _code { get; set; } = String.Empty;
	private bool _viewCode { get; set; } = false;

	public string DisplayMode {
		get => _displayMode;
		set {
			_displayMode = value;
			OnBlockChanged?.Invoke(Code, value);
		}
	}
	public class Author {
		public string Name { get; set; } = String.Empty;
		public string? Url { get; set; } = null;
		public string? Image { get; set; } = null;
		public Dictionary<string, string> Socials { get; set; } = new Dictionary<string, string>();
	}
	public List<Author> Authors { get; set; } = new List<Author>();
	public string Code {
		get => _code;
		set {
			_code = value;
			OnBlockChanged?.Invoke(value, DisplayMode);
		}
	}
	public bool ViewCode {
		get => _viewCode;
		set {
			_viewCode = value;
			OnBlockChanged?.Invoke(Code, DisplayMode);
		}
	}
	public event Action<string?, string?>? OnBlockChanged = null;
}