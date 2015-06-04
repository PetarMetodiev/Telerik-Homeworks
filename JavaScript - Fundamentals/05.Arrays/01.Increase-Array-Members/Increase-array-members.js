var arr = new Array(20),
	i, len;
for (i = 0, len = arr.length; i < len; i += 1) {
	arr[i] = i * 5;
}
for (i = 0, len = arr.length; i < len; i += 1) {
	console.log(arr[i]);
}