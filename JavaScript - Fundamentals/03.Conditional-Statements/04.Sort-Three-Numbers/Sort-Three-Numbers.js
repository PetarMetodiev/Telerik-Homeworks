var a = 15,
	b = 7,
	c = 59,
	result = [];
if (isNaN(a) || isNaN(b) || isNaN(c)) {
	result = !result;
} else if (a >= b && a >= c) {
	if (b >= c) {
		result = [a, b, c];
	} else {
		result = [a, c, b];
	}
} else if (b > a && b >= c) {
	if (a >= c) {
		result = [b, a, c];
	} else {
		result = [b, c, a];
	}
} else {
	if (a >= b) {
		result = [c, a, b];
	} else {
		result = [c, b, a];
	}
}
if (result) {
	console.log(result.join(', '));
} else {
	console.log('Invalid sequence!');
}