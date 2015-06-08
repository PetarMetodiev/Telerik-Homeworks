var input = 5698.21;

function reverseNumber(number) {
	number = number || 0;
	var isNegative = false;
	if (number < 0) {
		number *= -1;
		isNegative = true;
	}
	number = number.toString();
	if (isNegative) {
		return -(number.split('').reverse().join(''));
	}
	return (number.split('').reverse().join(''));
}

console.log(reverseNumber(input));