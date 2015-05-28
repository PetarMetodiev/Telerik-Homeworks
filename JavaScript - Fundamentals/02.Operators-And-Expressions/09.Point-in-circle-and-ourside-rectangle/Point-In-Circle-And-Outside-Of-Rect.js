function checkPosition(x, y) {
	var isInCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= 3 * 3;
	var isOutOfRectangle = !((x >= -1 && x <= -1 + 6) && (y <= 1 && y >= 1 - 2));
	return isInCircle && isOutOfRectangle;
}

console.log(checkPosition(1, 4));
console.log(checkPosition(3, 2));
console.log(checkPosition(0, 1));
console.log(checkPosition(4, 1));
console.log(checkPosition(2, 0));
console.log(checkPosition(4, 0));
console.log(checkPosition(2.5, 1.5));
console.log(checkPosition(3.5, 1.5));
console.log(checkPosition(-100, -100));