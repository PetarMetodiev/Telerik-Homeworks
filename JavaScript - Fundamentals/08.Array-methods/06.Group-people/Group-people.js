var result,
	currentLetter,
	maxAge = 100,
	person1 = makePerson('Ivan', 'Draganov', generateRandomAge(), false),
	person2 = makePerson('Ivanka', 'Draganova', generateRandomAge(), true),
	person3 = makePerson('Gosho', 'Peshev', generateRandomAge(), false),
	person4 = makePerson('Goshka', 'Pesheva', generateRandomAge(), true),
	person5 = makePerson('Stamat', 'Balkanski', generateRandomAge(), false),
	person6 = makePerson('Siika', 'Savova', generateRandomAge(), true),
	people = [person1, person2, person3, person4, person5, person6];

if (!Array.prototype.find) {
	Array.prototype.find = function(callback) {
		var i,
			len = this.length;
		for (i = 0; i < len; i += 1) {
			if (callback(this[i], i, this)) {
				return this[i];
			}
		}
	};
}

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

result = people.reduce(function(gr, person) {
	currentLetter = person.firstName[0];
	if (gr[currentLetter]) {
		gr[currentLetter].push(person);
	} else {
		gr[currentLetter] = [person];
	}
	return gr;
}, {});
console.log(result);