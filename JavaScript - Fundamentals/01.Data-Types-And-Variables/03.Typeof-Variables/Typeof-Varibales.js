var intVar = 55, 
	floatVar  = 1.95, 
	boolVar = true, 
	stringVar = 'Hi', 
	objectVar = {
		objName: 'Obj', 
		objCount: 1
	}, 
	arrayVar = [1,2,3];
functionVar = function(){
	console.log('This is a function');
};

var arrOfVars = [intVar,floatVar,boolVar,stringVar,objectVar,arrayVar,functionVar], i=0;
for(i=0;i<arrOfVars.length;i+=1){
	console.log('Type of ' + arrOfVars[i] + ' is: ' + typeof(arrOfVars[i]));
}