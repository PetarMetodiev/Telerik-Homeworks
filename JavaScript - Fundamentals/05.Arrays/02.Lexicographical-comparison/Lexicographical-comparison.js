var arr1 = ['a', 'b', 'h', 'l'],
	arr2 = ['a', 'c', 'H', 'f', 'p'],
	minLength = Math.min(arr1.length, arr2.length),
	i;

for (i = 0; i < minLength; i += 1) {
	if (arr1[i] === arr2[i]) {
		console.log(arr1[i] + ' = ' + arr2[i]);
	} else if (arr1[i] > arr2[i]) {
		console.log(arr1[i] + ' > ' + arr2[i]);
	} else {
		console.log(arr1[i] + ' < ' + arr2[i]);
	}
}