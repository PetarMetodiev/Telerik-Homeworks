var arr = [],
	maxCount = 1,
	currentCount = 1,
	maxArrayElements = 20,
	rangeOfArray = 10,
	i,
	repeatedElement,
	len,
	lastIndexOfMaxCount;
for (i = 0; i < maxArrayElements; i += 1) {
	arr[i] = Math.floor(Math.random() * rangeOfArray);
}
console.log(arr);
for (i = 0, len = arr.length - 1; i < len; i += 1) {
	if (arr[i] === arr[i + 1]) {
		currentCount += 1;
	} else {
		currentCount = 1;
	}
	if (currentCount > maxCount) {
		maxCount = currentCount;
		repeatedElement = arr[i];
		lastIndexOfMaxCount = i + 1;
	}
}
if (maxCount > 1) {
	console.log(arr.slice((lastIndexOfMaxCount - maxCount + 1), lastIndexOfMaxCount + 1));
} else {
	console.log('No repeating elements.');
}