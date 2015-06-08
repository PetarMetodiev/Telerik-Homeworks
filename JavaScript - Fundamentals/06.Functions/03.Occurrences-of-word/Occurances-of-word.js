var str = 'This is a sample string that is historical in the context of this impressive visualisation of the power of ordinary people using JavaScript';

function countOccurances(string, wordToBeCounted) {
	string = string || '';
	wordToBeCounted = wordToBeCounted || 'is';
	reg = new RegExp(wordToBeCounted, "gi");
	return string.match(reg).length;
}

console.log(countOccurances(str, 's'));
console.log(countOccurances(str));