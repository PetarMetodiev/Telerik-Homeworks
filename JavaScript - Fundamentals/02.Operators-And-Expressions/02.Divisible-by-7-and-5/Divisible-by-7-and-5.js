var numbers = [3, 0, 5, 7, 35, 140],
    i;
for (i = 0; i < numbers.length; i += 1) {
    if (isNaN(numbers[i])) {
        console.log('Not a valid number!');
    } else if (numbers[i] % 7 || numbers[i] % 5) {
        console.log('False');
    } else {
        console.log('True');
    }
}