/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function() {
		// var fullname;
		function Person(firstName, lastName, age) {
			validateNames(firstName, lastName);
			validateAge(age);
			this.firstname = firstName;
			this.lastname = lastName;
			this.age = +age;
		}

		Object.defineProperty(Person.prototype, 'fullname', {
			get: function() {
				return this.firstname + ' ' + this.lastname;
			},
			set: function(value) {
				var names = value.split(' ');
				validateNames(names[0], names[1]);
				this.firstname = names[0];
				this.lastname = names[1];
			}
		});

		Person.prototype.introduce = function() {
			return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
		};

		function validateNames() {
			var args = arguments,
				i,
				len;
			for (i = 0, len = args.length; i < len; i += 1) {
				if (!/^[A-Za-z]{3,20}$/.test(args[i])) {
					throw new Error('Invalid name!');
				}
			}
		}

		function validateAge(inputAge) {
			if (isNaN(inputAge)) {
				throw new Error('Invalid age!');
			}
			if (inputAge < 0 || inputAge > 150) {
				throw new Error('Age not in valid range!');
			}
		}

		return Person;
	}());
	return Person;
}
module.exports = solve;