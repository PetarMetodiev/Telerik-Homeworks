var i,
    len;

function isPrimeNum(number) {
    number = number || 0;
    number = Math.abs(number);
    if (number < 2) {
        return false;
    }
    for (i = 2, len = Math.sqrt(number); i <= len; i += 1) {
        if ((number % i)) {
            return false;
        }
    }
    return true;
}
console.log('Is the number prime? ' + isPrimeNum(10));