var obj = {
	name: 'Property',
	age: 1,
	length: 34,
	comments: 'No comment'
};

function hasProperty(object, property) {
	if (object[property]) {
		return true;
	}
	return false;
}

console.log(hasProperty(obj, 'length'));
console.log(hasProperty(obj, 'gender'));