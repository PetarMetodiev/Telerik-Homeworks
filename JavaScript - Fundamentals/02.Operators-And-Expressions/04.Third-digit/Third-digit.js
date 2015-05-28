var numbers = [5, 701, 1732, 9703, 877, 777877, 9999799, 'kon'],
    i;
for (i = 0; i < numbers.length; i += 1) {
    if (isNaN(numbers[i])) {
        console.log('Not a valid number!');
    } else if (Math.floor((numbers[i] / 100) % 10) === 7) {
        console.log('true');
    } else {
        console.log('false');
    }
}