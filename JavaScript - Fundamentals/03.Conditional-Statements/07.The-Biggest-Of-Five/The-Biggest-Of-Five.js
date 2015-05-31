var a = 5,
	b = 14,
	c = 113,
	d = 1112,
	e = 11111;
if (a >= b && a >= c && a >= d && a >= e) {
	console.log(a);
} else if (b >= c && b >= d && b >= e) {
	console.log(b);
} else if (c >= d && c >= e) {
	console.log(c);
} else if (d >= e) {
	console.log(d);
} else {
	console.log(e);
}