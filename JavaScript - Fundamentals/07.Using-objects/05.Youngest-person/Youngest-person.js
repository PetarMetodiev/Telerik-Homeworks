var people = [
	makePerson('Pesho', 'Peshev', 32),
	makePerson('Gosho', 'Goshev', 65),
	makePerson('Ivan', 'Ivanov', 13),
	makePerson('Stefan', 'Stefanov', 89)
];

function makePerson(fName, lName, age) {
	fName = fName || 'Test';
	lName = lName || 'Test';
	age = age || 0;
	return {
		firstName: fName,
		lastName: lName,
		age: age
	};
}

function comparer(a, b) {
	if (a.age < b.age) {
		return -1;
	}
	if (a.age > b.age) {
		return 1;
	}
	return 0;
}
people.sort(comparer);
console.log(people[0].firstName + ' ' + people[0].lastName);