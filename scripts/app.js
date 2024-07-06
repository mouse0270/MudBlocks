window.showLineNumbers = () => {
	setTimeout(() => {
		hljs.initLineNumbersOnLoad();
	}, 100);
};
window.setHLJSStyle = (themeMode) => {
	console.log('Setting HLJS Style: ', themeMode);
	document.querySelector('link[href*="atom-one-dark"]').setAttribute('rel', themeMode.toLowerCase() === "true" ? 'stylesheet' : 'disabled');
	document.querySelector('link[href*="atom-one-light"]').setAttribute('rel', themeMode.toLowerCase() === "false" ? 'stylesheet' : 'disabled');
	document.documentElement.setAttribute('data-theme', themeMode.toLowerCase() === "true" ? 'dark' : 'light');
};

window.copyToClipboard = (text) => {
	// URL Decode Text
	text = decodeURIComponent(text.replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/&quot;/g, '"'));

	navigator.clipboard.writeText(text).then(function () {
		console.log('Text copied to clipboard');
	}).catch(function (err) {
		console.error('Could not copy text: ', err);
	});
};

window.getInnterText = (id) => {
	var ele = document.getElementById(id);
	return ele == null ? "" : ele.innerText;
};

window.setInnerHtml = (id, txt) => {
	document.getElementById(id).innerHTML = txt;
}

window.highlightElementById = (id) => {
	return hljs.highlightElement(document.getElementById(id));
};

window.loadCss = (url) => {
	if (!url || url.length === 0) {
		throw new Error('argument "url" is required !');
	}
	var head = document.getElementsByTagName('head')[0];
	var link = document.createElement('link');
	link.href = url;
	link.rel = 'stylesheet';
	link.type = 'text/css';
	head.appendChild(link);
};