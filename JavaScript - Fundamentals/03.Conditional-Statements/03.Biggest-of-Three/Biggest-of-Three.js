var a = 0,
	b = 99,
	c = 3.14,
	biggest;
if (isNaN(a) || isNaN(b) || isNaN(c)) {
	biggest = NaN;
} else if (a >= b && a >= c) {
	biggest = a;
} else if (b >= a && b >= c) {
	biggest = b;
} else {
	biggest = c;
}
console.log('The greatest number of ' + a + ', ' + b + ' and ' + c + ' is ' + biggest);