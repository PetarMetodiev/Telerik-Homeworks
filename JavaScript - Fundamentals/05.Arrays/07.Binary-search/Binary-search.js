var arr = [],
	i,
	len,
	maxArrayElements = 20,
	rangeOfArray = 10,
	start,
	end,
	mid,
	resultIndex = 0,
	searchedValue = 6;

for (i = 0; i < maxArrayElements; i += 1) {
	arr[i] = Math.floor(Math.random() * rangeOfArray);
}

arr.sort(function(x, y) {
	return x - y;
});

console.log(arr);

start = 0;
end = arr.length;
mid = Math.floor((start + end) / 2);

while (end >= start) {
	mid = Math.floor((start + end) / 2);
	if (arr[mid] < searchedValue) {
		start = mid + 1;
	} else if (arr[mid] > searchedValue) {
		end = mid - 1;
	} else {
		resultIndex = mid;
		break;
	}
}

if (resultIndex) {
	console.log(searchedValue + ' is at position ' + resultIndex + ' in the sorted aray.');
} else {
	console.log(searchedValue + ' is not in the array!');
}