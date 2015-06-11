console.log('((a+b)/5-d) - ' + isCorrectExpression('((a+b)/5-d)'));
console.log(')(a+b)) - ' + isCorrectExpression(')(a+b))'));

function isCorrectExpression(expr) {
	var check = 0;

	for (var ind = 0; ind < expr.length; ind++) {
		if (expr[ind] === '(') {
			check++;
		} else if (expr[ind] === ')') {
			check--;
		}

		if (check < 0) {
			return 'incorrect';
		}
	}

	return check ? 'incorrect' : 'correct';
}