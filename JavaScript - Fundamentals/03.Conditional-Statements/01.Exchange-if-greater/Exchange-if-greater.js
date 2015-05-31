var firstNumber = 5.5,
	secondNumber = 4.5,
	temp = 1;
if (firstNumber > secondNumber) {
	temp = secondNumber;
	secondNumber = firstNumber;
	firstNumber = temp;
}

console.log(firstNumber + ' ' + secondNumber);