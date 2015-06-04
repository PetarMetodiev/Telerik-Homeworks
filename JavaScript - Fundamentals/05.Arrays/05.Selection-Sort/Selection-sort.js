var arr = [64, 25, 12, 22, 11],
	i,
	j,
	len,
	min,
	temp;
for (i = 0, len = arr.length; i < len - 1; i++) {
	min = i;
	for (j = i + 1; j < len; j++) {
		if (arr[j] < arr[min]) {
			min = j;
		}
	}
	temp = arr[i];
	arr[i] = arr[min];
	arr[min] = temp;
}
console.log(arr);