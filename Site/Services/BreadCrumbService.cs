namespace MudBlocks.Site.Services;

public class BreadCrumbService {
	public event Action OnChange = delegate { };

	private readonly List<MudBlazor.BreadcrumbItem> _breadcrumbs = new List<MudBlazor.BreadcrumbItem>() {
		new MudBlazor.BreadcrumbItem("MudBlocks", href: "/", icon: MudBlazor.Icons.Material.Filled.Home)
	};

	public IReadOnlyList<MudBlazor.BreadcrumbItem> Breadcrumbs => _breadcrumbs;

	public void Set(IEnumerable<MudBlazor.BreadcrumbItem> items)
	{
		_breadcrumbs.Clear();

		// Always Prefix with home if not included
		if (items.FirstOrDefault()?.Href != "/")
		{
			_breadcrumbs.Add(new MudBlazor.BreadcrumbItem("MudBlocks", href: "/", icon: MudBlazor.Icons.Material.Filled.Home));
		}

		_breadcrumbs.AddRange(items);

		// Update the UI
		NotifyStateChanged();
	}

	public void Add(MudBlazor.BreadcrumbItem item) {
		_breadcrumbs.Add(item);

		// Update the UI
		NotifyStateChanged();
	}

	public void Remove(MudBlazor.BreadcrumbItem item) {
		// If item exists, remove it otherwise try to find index of matching details
		if (_breadcrumbs.Contains(item)) {
			_breadcrumbs.Remove(item);
		} else if (_breadcrumbs.Any(b => b.Text == item.Text && b.Href == item.Href && b.Icon == item.Icon)) {
			_breadcrumbs.RemoveAt(_breadcrumbs.FindIndex(b => b.Text == item.Text && b.Href == item.Href && b.Icon == item.Icon));
		} else if (_breadcrumbs.Any(b => b.Text == item.Text && b.Href == item.Href)) {
			_breadcrumbs.RemoveAt(_breadcrumbs.FindIndex(b => b.Text == item.Text && b.Href == item.Href));
		} else if (_breadcrumbs.Any(b => b.Text == item.Text)) {
			_breadcrumbs.RemoveAt(_breadcrumbs.FindIndex(b => b.Text == item.Text));
		} else if (_breadcrumbs.Any(b => b.Href == item.Href)) {
			_breadcrumbs.RemoveAt(_breadcrumbs.FindIndex(b => b.Href == item.Href));
		} else {
			// If no match found then remove nothing
			return;
		}

		// Update the UI
		NotifyStateChanged();
	}

	public void Clear() {
		_breadcrumbs.Clear();

		// Always Prefix with home if not included
		_breadcrumbs.Add(new MudBlazor.BreadcrumbItem("MudBlocks", href: "/", icon: MudBlazor.Icons.Material.Filled.Home));

		// Update the UI
		NotifyStateChanged();
	}

	public List<MudBlazor.BreadcrumbItem> Get() {
		return _breadcrumbs;
	}

	public List<MudBlazor.BreadcrumbItem> GetRange(int index, int? count) {
		return _breadcrumbs.GetRange(index, count ?? _breadcrumbs.Count - index);
	}

	public string GetText(string separator = " / ") {
		if (_breadcrumbs.Count == 0) {
			return "MudBlocks";
		} else if (_breadcrumbs.Count > 1) {
			// Remove Dashboard from the Breadcrumbs
			return $"MudBlocks {separator} {string.Join(separator, _breadcrumbs.Skip(1).Select(b => b.Text))}";
		}

		return $"MudBlocks {separator} {string.Join(separator, _breadcrumbs.Select(b => b.Text))}";
	}

	private void NotifyStateChanged() => OnChange?.Invoke();
}