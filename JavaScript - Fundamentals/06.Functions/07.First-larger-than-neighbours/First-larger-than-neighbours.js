var arr = [], //  = [1, 2, 4, 4, 3, 6, 6, 9, 9, 2, 2, 7]
	position = arr.length - 1, // position = 3, position = -3, position = 4
	maxArrayElements = 20,
	rangeOfArray = 10;

for (i = 0; i < maxArrayElements; i += 1) {
	arr[i] = Math.floor(Math.random() * rangeOfArray);
}

console.log(arr);

function getIndexOfFirstLarger(array) {
	var len = array.length,
		i;
	if (array[0] > array[1]) {
		return 0;
	}
	for (i = 1; i < len - 1; i += 1) {
		if ((array[i] > array[i - 1]) && (array[i] > array[i + 1])) {
			return i;
		}
	}
	if (array[len - 1] > array[len - 2]) {
		return len - 1;
	}
	return -1;
}

console.log(getIndexOfFirstLarger(arr));