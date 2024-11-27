let blazorComponent;

// Register the Blazor component
function registerBlazorComponent(dotNetObject) {
	blazorComponent = dotNetObject;
}

// Set Session Storage
function initializeThemeOptions() {
	const isDarkMode = window.getStorage("isDarkMode");
	const themeColor = getStorage("themeColor");
	const themeMode = getStorage("themeMode");
	const themeFont = getStorage("themeFont");

	if (isDarkMode === null) {
		const prefersDarkScheme = window.matchMedia("(prefers-color-scheme: dark)").matches;
		setStorage("isDarkMode", prefersDarkScheme);
	}

	if (themeColor === null) {
		setStorage("themeColor", "DeepPurple");
	}

	if (themeMode === null) {
		setStorage("themeMode", "Monochromatic");
	}

	if (themeFont === null) {
		setStorage("themeFont", "Roboto");
	}
}

window.setStorage = function (key, value) {
	try {
		localStorage.setItem(key, value);
	} catch (e) {
		console.error("Error setting session storage:", e);
	}
};

window.getStorage = function (key) {
	try {
		return localStorage.getItem(key);
	} catch (e) {
		console.error("Error getting session storage:", e);
	}
}

window.ToggleDarkMode = function () {
	const isDarkMode = window.getStorage("isDarkMode") === "true";
	const themeColor = window.getStorage("themeColor");
	const themeMode = window.getStorage("themeMode");
	const themeFont = window.getStorage("themeFont");

	window.postMessage({
		type: 'setThemeOptions',
		isDarkMode: !isDarkMode,
		themeColor: themeColor,
		themeMode: themeMode,
		themeFont: themeFont
	}, '*');
};

window.setThemeOptions = function (isDarkMode, themeColor, themeMode, themeFont, fontUrl) {
	// Save theme options to session storage
	setStorage("isDarkMode", isDarkMode ?? window.getStorage("isDarkMode"));
	setStorage("themeColor", themeColor ?? window.getStorage("themeColor"));
	setStorage("themeMode", themeMode ?? window.getStorage("themeMode"));
	setStorage("themeFont", themeFont ?? window.getStorage("themeFont"));

	// Update Code Block Theme
	document.head.querySelector(`link[href*="prism-material-"]`).href = `/assets/styles/prism-material-${isDarkMode ? "dark" : "light"}.css`;

	// Send theme options to all iframes
	document.querySelectorAll("iframe").forEach(iframe => {
		if (iframe.contentWindow != null) {
			try {
				if (iframe.contentWindow == null) return;

				let fontLink = iframe.contentDocument.querySelector("link[href*='fonts.googleapis.com'][rel='stylesheet']");
				if (fontLink) {
					iframe.contentWindow.postMessage({ type: 'setThemeOptions', isDarkMode, themeColor, themeMode, themeFont }, "*");
					if (fontLink) fontLink.href = fontUrl;
				}
				
				iframe.onload = () => {
					try {
						fontLink = iframe.contentDocument.querySelector("link[href*='fonts.googleapis.com'][rel='stylesheet']");
						iframe.contentWindow.postMessage({ type: 'setThemeOptions', isDarkMode, themeColor, themeMode, themeFont }, "*");
						if (fontLink) fontLink.href = fontUrl;
					}catch(e){
						//console.error(e);
					}
				};
			}catch(e){
				//console.error(e);
			}
		}
	});
};

window.CopyToClipBoard = function (text) {
	navigator.clipboard.writeText(text).then(() => {
		console.log("Copied to clipboard:", text);
	});
};

window.addEventListener("message", async (event) => {
	if (event.data && event.data.type == "setThemeOptions") {
		const { isDarkMode, themeColor, themeMode, themeFont } = event.data;

		if (blazorComponent) {
			blazorComponent.invokeMethodAsync("SetThemeOptions", isDarkMode, themeColor, themeMode, themeFont);
		} else {
			console.warn("Blazor component not registered.");
		}
	}
});

initializeThemeOptions();