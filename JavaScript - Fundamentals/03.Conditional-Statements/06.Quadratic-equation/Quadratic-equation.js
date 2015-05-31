var a = -0.5,
	b = 4,
	c = -8,
	d,
	result = [];
d = b * b - 4 * a * c;
// I know it could be a bit shorter if I used variables instead of an array, but I wanted to exercise truthy and falsy expressions.
if (!d) {
	result[0] = (-b) / (2 * a);
	result[0] = Math.round(result[0] * 100) / 100;
} else if (d > 0) {
	result[0] = (-b + Math.sqrt(d)) / (2 * a);
	result[0] = Math.round(result[0] * 100) / 100;
	result[1] = (-b - Math.sqrt(d)) / (2 * a);
	result[1] = Math.round(result[1] * 100) / 100;
}
if (!result.length) {
	console.log('No real roots');
	// console.log('Entered');
} else if (result.length > 1) {
	console.log('x1 = ' + result[0] + ', x2 = ' + result[1]);
} else {
	console.log('x1 = x2 = ' + result[0]);
}