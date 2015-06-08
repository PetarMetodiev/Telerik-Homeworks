// Write functions for working with shapes in standard Planar coordinate system.
// Points are represented by coordinates P(X, Y)
// Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
// Calculate the distance between two points.
// Check if three segment lines can form a triangle.

var point1 = makePoint(3, 2),
	point2 = makePoint(9, 7),
	lineOne = makeLine(point1, point2),
	lineTwo = makeLine(makePoint(2, 3), makePoint(0, 0)),
	lineThree = makeLine(makePoint(-1, 4), makePoint(-2, -4));

function makePoint(inputX, inputY) {
	return {
		x: inputX,
		y: inputY,
		printPoint: function() {
			console.log('x = ' + this.x);
			console.log('y = ' + this.y);
		}
	};
}

function makeLine(pointA, pointB) {
	pointA = pointA || makePoint(0, 0);
	pointB = pointB || makePoint(0, 0);
	return {
		pointA: pointA,
		pointB: pointB,
		printLine: function() {
			console.log('Start: ');
			pointA.printPoint();
			console.log('End: ');
			pointB.printPoint();
		}
	};
}

function calculateLength(line) {
	line = line || makeLine((makePoint(0, 0), makePoint(0, 0)));
	var pointA = line.pointA,
		pointB = line.pointB;
	var distance = Math.sqrt((pointA.x - pointB.x) * (pointA.x - pointB.x) + (pointA.y - pointB.y) * (pointA.y - pointB.y));
	distance = Math.round(distance * 100) / 100;
	return distance;
}

// function areCollinear(pointA, pointB, pointC) {
//     pointA = pointA || makePoint(0, 0);
//     pointB = pointB || makePoint(0, 0);
//     pointC = pointB || makePoint(0, 0);
//     var a = pointA.x,
//         b = pointA.y,
//         m = pointB.x,
//         n = pointB.y,
//         k = pointC.x,
//         l = pointC.y;
//     // source: http://math.stackexchange.com/questions/405966/if-i-have-three-points-is-there-an-easy-way-to-tell-if-they-are-collinear
//     if ((n - b) * (k - m) === (l - n) * (m - a)) {
//         return true;
//     }
//     return false;
// }

function linesFormTriangle(lineA, lineB, lineC) {
	lineA = lineA || makeLine((makePoint(0, 0), makePoint(0, 0)));
	lineB = lineB || makeLine((makePoint(0, 0), makePoint(0, 0)));
	lineC = lineC || makeLine((makePoint(0, 0), makePoint(0, 0)));

	function areParallel(lineA, lineB) {

		function getSlope(line) {
			var x1 = line.pointA.x,
				x2 = line.pointB.x,
				y1 = line.pointA.y,
				y2 = line.pointB.y,
				slope;
			if ((x2 - x1) && (y2 - y1)) {
				slope = (y2 - y1) / (x2 - x1);
			} else {
				slope = 0;
			}

			return slope;
		}

		if (getSlope(lineA) === getSlope(lineB)) {
			return true;
		}
		return false;
	}

	if (areParallel(lineA, lineB) || areParallel(lineB, lineC) || areParallel(lineC, lineB)) {
		return false;
	}
	return true;

}

console.log('Distance between the points: ' + calculateLength(lineOne));
console.log();
console.log('Line One: ');
lineOne.printLine();
console.log();
console.log('Line Two: ');
lineTwo.printLine();
console.log();
console.log('Line Three: ');
lineThree.printLine();
console.log();
console.log('Can they form a triangle? ' + linesFormTriangle(lineOne, lineTwo, lineThree));