// Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time
var n = 50,
	i, notDivisible;
for (i = 1; i <= n; i += 1) {
	notDivisible = i % 3 || i % 7;
	if (notDivisible) {
		console.log(i);
	}
}