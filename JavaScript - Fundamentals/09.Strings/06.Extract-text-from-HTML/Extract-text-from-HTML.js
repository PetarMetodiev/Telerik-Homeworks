var html = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
var text = getText(html);
console.log(text);

function getText(html) {
	return html.replace(/<[^>]*>/g, '');
}