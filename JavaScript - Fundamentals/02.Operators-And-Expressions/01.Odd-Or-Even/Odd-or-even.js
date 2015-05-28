var numbers = [3,2,-2,-1,0,'asd','0', 3.14],
	i;

for(i=0;i<numbers.length;i+=1){
	if (isNaN(numbers[i])) {
		console.log('Not a valid number!');
	}
	else if(numbers[i]%2){
		console.log('Odd');
	}
	else{
		console.log('Even');
	}
}