var input,
	numbers = [],
	firstDigit,
	secondDigit,
	thirdDigit,
	i;

function getThirdDigit(number) {
	var result = number % 10;
	return result;
}

function getSecondDigit(number) {
	var result = Math.floor(number / 10) % 10;
	return result;
}

function getFirstDigit(number) {
		var result = Math.floor(number / 100) % 10;
		return result;
	}
	// console.log(Math.floor(345/100)%10);
function sayZeroToNineteen(number) {
	switch (number) {
		case 0:
			return 'Zero';
		case 1:
			return 'One';
		case 2:
			return 'Two';
		case 3:
			return 'Three';
		case 4:
			return 'Four';
		case 5:
			return 'Five';
		case 6:
			return 'Six';
		case 7:
			return 'Seven';
		case 8:
			return 'Eight';
		case 9:
			return 'Nine';
		case 10:
			return 'Ten';
		case 11:
			return 'Eleven';
		case 12:
			return 'Twelve';
		case 13:
			return 'Thirteen';
		case 14:
			return 'Fourteen';
		case 15:
			return 'Fifteen';
		case 16:
			return 'Sixteen';
		case 17:
			return 'Seventeen';
		case 18:
			return 'Eighteen';
		case 19:
			return 'Nineteen';
		default:
			return 'Invalid input';
	}
}

function sayTens(number) {
	switch (number) {
		case 1:
			return 'Ten';
		case 2:
			return 'Twenty';
		case 3:
			return 'Thirty';
		case 4:
			return 'Fourty';
		case 5:
			return 'Fifty';
		case 6:
			return 'Sixty';
		case 7:
			return 'Seventy';
		case 8:
			return 'Eighty';
		case 9:
			return 'Ninety';
		default:
			return 'Invalid input';
	}
}

function sayNumber(input) {
	firstDigit = getFirstDigit(input);
	secondDigit = getSecondDigit(input);
	thirdDigit = getThirdDigit(input);
	if (isNaN(input) || input < 0 || input > 999) {
		console.log('Invalid input!');
	} else if (input >= 0 && input <= 19) {
		console.log(sayZeroToNineteen(input));
	} else if (input < 100) {
		if (input % 10) { // If the second digit is not 0: 22 65 99 36 ...
			console.log(sayTens(secondDigit) + ' ' + sayZeroToNineteen(thirdDigit).toLowerCase());
		} else {
			console.log(sayTens(secondDigit));
		}
	} else {
		if (input % 100) { // if the number is not whole hundred: 100 200 300...
			if (!thirdDigit) { //If the third digit is 0: 110 120,...
				console.log(sayZeroToNineteen(firstDigit) + ' hundred and ' + sayTens(secondDigit).toLowerCase());
			} else if (!secondDigit) { // if the second digit is 0: 101 102...
				console.log(sayZeroToNineteen(firstDigit) + ' hundred and ' + sayZeroToNineteen(thirdDigit).toLowerCase());
			} else if (secondDigit === 1) { // If the number is between x10 and x19: 112 918 416 ...
				console.log(sayZeroToNineteen(firstDigit) + ' hundred and ' + sayZeroToNineteen(thirdDigit + 10).toLowerCase());
			} else { // If the number is between x20 and x99: 365 254 999 ...
				console.log(sayZeroToNineteen(firstDigit) + ' hundred and ' + sayTens(secondDigit).toLowerCase() + ' ' + sayZeroToNineteen(thirdDigit).toLowerCase());
			}
		} else { // If the number is a whole hundred: 100 200 300 400...
			console.log(sayZeroToNineteen(firstDigit) + ' hundred');
		}
	}
}
for (i = 0; i <= 999; i += 1) {
	numbers[i] = i;
}
for (i = 0; i <= 999; i += 1) {
	sayNumber(numbers[i]);
}