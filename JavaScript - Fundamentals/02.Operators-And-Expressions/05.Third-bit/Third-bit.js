var numbers = [5, 8, 0, 15, 5343, 62241, 'prase'],
    i,
    mask = 8; // same as 1 << 3 (1000 in binary)
for (i = 0; i < numbers.length; i += 1) {
    if (isNaN(numbers[i])) {
        console.log('Invalid number!');
    } else {
        console.log((numbers[i] & mask) >> 3);
    }
}