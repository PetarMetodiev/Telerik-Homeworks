var person,
	vasil = buildPerson('Vasil', 'Vasilev', 30),
	angel = buildPerson('Angel', 'Vasilev', 35),
	todor = buildPerson('Vasil', 'Donev', 20),
	stamen = buildPerson('Stamen', 'Donev', 30),
	vera = buildPerson('Vera', 'Peicheva', 30),
	people = [vasil, angel, todor, stamen, vera],
	groupedByFname = groupBy(people, 'firstName'),
	groupedByLname = groupBy(people, 'lastName'),
	groupedByAge = groupBy(people, 'age');

function buildPerson(firstName, lastName, age) {
	return {
		firstName: firstName,
		lastName: lastName,
		age: age,
		toString: function getFullName() {
			return this.firstName + " " + this.lastName + ' ' + this.age + ' years old';
		}
	};
}

function groupBy(array, prop) {
	var i,
		len,
		result = {};

	for (i = 0, len = array.length; i < len; i += 1) {
		if (!result[array[i][prop]]) {
			result[array[i][prop]] = [];
		}
		result[array[i][prop]].push(array[i].toString());
	}
	return result;
}

for (person in people) {
	if (people.hasOwnProperty(person)) {
		console.log(people[person].toString());
	}
}

console.log('Grouped by first name:');
console.log(groupedByFname);
console.log('Grouped by last name:');
console.log(groupedByLname);
console.log('Grouped by age:');
console.log(groupedByAge);