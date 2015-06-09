var result,
	maxAge = 20,
	person1 = makePerson('Ivan', 'Draganov', generateRandomAge(), false),
	person2 = makePerson('Ivanka', 'Draganova', generateRandomAge(), true),
	person3 = makePerson('Gosho', 'Peshev', generateRandomAge(), false),
	person4 = makePerson('Goshka', 'Pesheva', generateRandomAge(), true),
	person5 = makePerson('Stamat', 'Balkanski', generateRandomAge(), false),
	people = [person1, person2, person3, person4, person5];

function generateRandomAge() {
	var age = Math.floor(Math.random() * maxAge);
	return age;
}

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

result = people.every(function(item) {
	return item.age >= 18;
});

people.forEach(function(person) {
	console.log(person.firstName + ' ' + person.lastName + '; Age ' + person.age);
});

if (result) {
	console.log('All people are at least 18 years old');
} else {
	console.log('There some underage people!');
}