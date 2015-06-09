var result,
	maxAge = 100,
	person1 = makePerson('Ivan', 'Draganov', generateRandomAge(), false),
	person2 = makePerson('Ivanka', 'Draganova', generateRandomAge(), true),
	person3 = makePerson('Gosho', 'Peshev', generateRandomAge(), false),
	person4 = makePerson('Goshka', 'Pesheva', generateRandomAge(), true),
	person5 = makePerson('Stamat', 'Balkanski', generateRandomAge(), false),
	person6 = makePerson('Siika', 'Savova', generateRandomAge(), true),
	people = [person1, person2, person3, person4, person5, person6];

function generateRandomAge() {
	var age = Math.floor(Math.random() * maxAge);
	return age;
}

function makePerson(firstName, lastName, age, gender) {
	firstName = firstName || 'Pesho';
	lastName = lastName || 'Peshev';
	age = age || 0;
	gender = gender || false;
	return {
		firstName: firstName,
		lastName: lastName,
		age: age,
		gender: gender // true is female, false is male
	};
}

people.forEach(function(person) {
	console.log(person.firstName + ' ' + person.lastName + '; Age ' + person.age + '; IsFemale?: ' + person.gender);
});

result = people
	.filter(function(person) {
		return person.gender;
	})
	.reduce(function(average, person, index) {
		return (average * index + person.age) / (index + 1);
	}, 0);

console.log();
console.log('Average female age: ' + Math.round(result * 100) / 100);