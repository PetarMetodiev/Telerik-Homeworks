var paragraph = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. ' +
	'Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

paragraph = replaceLinkTags(paragraph);
console.log(paragraph);

function replaceLinkTags(text) {
	var regex = /<\s*a\s+href\s*=\s*"(.*?)"\s*>(.*?)<\s*\/a\s*>/gi;

	return text.replace(regex, function(tag, url, content) {
		return '[URL=' + url + ']' + content + '[\/URL]';
	});
}