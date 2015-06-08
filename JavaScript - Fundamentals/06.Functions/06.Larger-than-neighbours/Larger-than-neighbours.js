var arr = [1, 2, 4, 7, 3, 6, 6, 9, 8, 2, 2, 7],
	position = arr.length - 1, // position = 3, position = -3, position = 4
	i,
	len;

function isLargerThanNeighbours(array, inputPosition) {
	array = array || [];
	inputPosition = inputPosition || (array.length / 2);
	if (!inputPosition) {
		if (array[inputPosition] > array[inputPosition + 1]) {
			return true;
		}
	} else if (inputPosition === array.length - 1) {
		if (array[inputPosition] > array[inputPosition - 1]) {
			return true;
		}
	} else {
		if ((array[inputPosition] > array[inputPosition + 1]) && (array[inputPosition] > array[inputPosition - 1])) {
			return true;
		}
	}
	return false;
}

result = isLargerThanNeighbours(arr, position);

if (result) {
	console.log('The element at position ' + position + ' is larger than its neightbours');
} else {
	console.log('The element at position ' + position + ' is not larger than its neightbours');
}