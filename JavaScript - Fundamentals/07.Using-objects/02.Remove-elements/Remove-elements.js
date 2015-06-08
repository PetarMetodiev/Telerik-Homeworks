var arr = [1, 'kon', 1, 'kon', 4, 1, 3, 4, 1, 111, 'kon', 3, 2, 1, '1', 'kon'],
	i,
	len;
if (!Array.prototype.remove) {
	Array.prototype.remove = function(numberToRemove) {
		for (i = 0, len = this.length; i < len; i += 1) {
			if (this[i] === numberToRemove) {
				this.splice(i, 1);
			}
		}
	};
}
console.log(arr);
arr.remove(1);
console.log(arr);