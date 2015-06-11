var str = 'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.',
	count;
count = (str.match(/in/gi) || []).length;

console.log(str);
console.log(count);