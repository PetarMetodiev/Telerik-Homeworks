var arr = [2, 3, 4, 5, 6, 7, 8, 3, 2, 2, 3, 2],
	i,
	len,
	maxLength = 1,
	currentLength = 1,
	lastIndexOfSequence = 0,
	maxArrayElements = 20,
	rangeOfArray = 5;
for (i = 0; i < maxArrayElements; i += 1) {
	arr[i] = Math.floor(Math.random() * rangeOfArray);
}
console.log(arr);
for (i = 0, len = arr.length; i < len - 1; i += 1) {
	if ((arr[i] + 1) === (arr[i + 1])) {
		currentLength += 1;
	} else {
		currentLength = 1;
	}
	if (currentLength > maxLength) {
		maxLength = currentLength;
		lastIndexOfSequence = i + 1;
	}
}
if (maxLength > 1) {
	console.log(arr.slice((lastIndexOfSequence - maxLength + 1), lastIndexOfSequence + 1));
} else {
	console.log('No increasing sequence.');
}