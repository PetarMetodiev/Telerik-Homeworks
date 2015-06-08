var arr = [1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5],
	i;

function countAppearances(array, number) {
	var len,
		counter = 0;

	arr = array || [];
	number = number || 0;

	for (i = 0, len = array.length; i < len; i += 1) {
		if (array[i] === number) {
			counter += 1;
		}
	}
	return counter;
}

function testFunction() {
	var arrTest = [1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5];
	var test1 = countAppearances(arrTest, 1),
		test2 = countAppearances(arrTest, 2),
		test3 = countAppearances(arrTest, 3),
		test4 = countAppearances(arrTest, 4),
		test5 = countAppearances(arrTest, 5),
		test1ExpectedResult = 1,
		test2ExpectedResult = 2,
		test3ExpectedResult = 3,
		test4ExpectedResult = 4,
		test5ExpectedResult = 5;
	console.log('Calculated: ' + test1 + '; Expected: ' + test1ExpectedResult);
	console.log('Calculated: ' + test2 + '; Expected: ' + test2ExpectedResult);
	console.log('Calculated: ' + test3 + '; Expected: ' + test3ExpectedResult);
	console.log('Calculated: ' + test4 + '; Expected: ' + test4ExpectedResult);
	console.log('Calculated: ' + test5 + '; Expected: ' + test5ExpectedResult);
}

testFunction();