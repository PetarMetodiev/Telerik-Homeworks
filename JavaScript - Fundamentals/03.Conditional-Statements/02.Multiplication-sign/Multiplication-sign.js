var a = 123,
	b = -4,
	c = 9,
	sign, result;
if (a === 0 || b === 0 || c === 0 || isNaN(a) || isNaN(b) || isNaN(c)) {
	sign = ''; // empty string results in falsy statement
} else if ((a < 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c > 0) || (a > 0 && b > 0 && c < 0)) {
	sign = '-';
} else if ((a < 0 && b < 0 && c > 0) || (a < 0 && b > 0 && c < 0) || (a > 0 && b < 0 && c < 0)) {
	sign = '+';
} else {
	sign = '-';
}
if (!sign) {
	result = 'zero';
} else if (sign === '+') {
	result = 'positive';
} else {
	result = 'negative';
}
// console.log(!!sign);
console.log('The product of ' + a + ', ' + b + ' and ' + c + ' is ' + result);