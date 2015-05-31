var i, min, max, len, sequence = [];
for (i = 0; i < 20; i += 1) {
	sequence[i] = Math.floor(Math.random() * 100);
}
min = sequence[0];
max = sequence[0];
for (i = 0, len = sequence.length; i < len; i += 1) {
	if (sequence[i] < min) {
		min = sequence[i];
	}
	if (sequence[i] > max) {
		max = sequence[i];
	}
	console.log(sequence[i]);
}
console.log('Max value in sequence: ' + max);
console.log('Min value in sequence: ' + min);