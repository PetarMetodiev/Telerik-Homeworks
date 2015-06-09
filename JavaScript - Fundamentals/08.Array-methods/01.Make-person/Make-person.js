var person1 = makePerson('Ivan', 'Draganov', 21, false),
	person2 = makePerson('Ivanka', 'Draganova', 25, true),
	person3 = makePerson('Gosho', 'Peshev', 14, false),
	person4 = makePerson('Goshka', 'Pesheva', 17, true),
	person5 = makePerson('Stamat', 'Balkanski', 81, false),
	people = [person1, person2, person3, person4, person5];

function makePerson(firstName, lastName, age, gender) {
	firstName = firstName || 'Pesho';
	lastName = lastName || 'Peshev';
	age = age || 0;
	gender = gender || true;
	return {
		firstName: firstName,
		lastName: lastName,
		age: age,
		gender: gender // true is female, false is male
	};
}

console.log(people);