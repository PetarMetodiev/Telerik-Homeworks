/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    var Course = {
        init: function (title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this.students = [];
            this.nextStudentID = 0;
            return this;
        },

        addStudent: function (name) {
            this.name = name;
            this.nextStudentID += 1;
            this.students.push({
                firstname: this.name.split(' ')[0],
                lastname: this.name.split(' ')[1],
                id: this.nextStudentID
            });
            return this.nextStudentID;
        },

        getAllStudents: function () {
            var sortedStudents = this.students.sort(function (a, b) {
                return a.ID - b.ID;
            });

            return sortedStudents;
        },

        submitHomework: function (studentID, homeworkID) {
            if (!isStudentIDvalid.call(this, studentID)) {
                throw new Error('Invalid student ID!');
            }
            if (!this.presentations[homeworkID - 1]) {
                throw new Error('Invalid homeworkID!');
            }
        },

        pushExamResults: function (results) {
            if (!isExamResultValid.call(this, results)) {
                throw new Error('Invalid exam results!');
            }
        },

        getTopStudents: function () {
            //
        }
    };

    Object.defineProperty(Course, 'title', {
        get: function () {
            return this._title;
        },
        set: function (value) {
            if (!isTitleValid(value)) {
                throw new Error('Invalid title!');
            }
            this._title = value;
        }
    });

    Object.defineProperty(Course, 'presentations', {
        get: function () {
            return this._presentations;
        },
        set: function (value) {
            if (!value || !value.length) {
                throw new Error('Invalid presentations!');
            }
            if (!value.every(function (item) {
                return isTitleValid(item);
            })) {
                throw new Error('Invalid presentations!');
            }
            this._presentations = value;
        }
    });

    Object.defineProperty(Course, 'name', {
        get: function () {
            return this._name;
        },
        set: function (value) {
            if (!isNameValid(value)) {
                throw new Error('Invalid name!');
            }
            this._name = value;
        }
    });

    Object.defineProperty(Course, 'nextStudentID', {
        get: function () {
            return this._nextStudentID;
        },
        set: function (value) {
            this._nextStudentID = value;
        },
        enumerable: false
    });

    Object.defineProperty(Course, 'students', {
        get: function () {
            return this._students;
        },
        set: function (value) {
            this._students = value;
        }
    });

    function isTitleValid(inputTitle) {
        var i,
            len,
            currentSymbol,
            nextSymbol;
        if (!inputTitle.length) {
            return false;
        }
        if ((!inputTitle.indexOf(' ')) || (inputTitle.lastIndexOf(' ') === (inputTitle.length - 1))) {
            return false;
        }
        for (i = inputTitle.indexOf(' '), len = inputTitle.lastIndexOf(' '); i < len; i += 1) {
            currentSymbol = inputTitle[i];
            nextSymbol = inputTitle[i + 1];
            if ((currentSymbol === ' ') && (nextSymbol === ' ')) {
                return false;
            }
        }

        return true;
    };

    function isNameValid(inputName) {
        var i,
            len,
            currentName;
        var nameAsArray = inputName.split(' ');
        if (typeof inputName !== 'string') {
            return false;
        }

        if (nameAsArray.length !== 2) {
            return false;
        }

        for (i = 0, len = nameAsArray.length; i < len; i += 1) {
            currentName = nameAsArray[i];

            if (currentName[0].toUpperCase() !== currentName[0]) {
                return false;
            }

            if (currentName.slice(1).toLowerCase() !== currentName.slice(1)) {
                return false;
            }
        }
        return true;
    };

    function isStudentIDvalid(inputID) {
        return this.students.some(function (st) {
            return st.id === inputID;
        });
    }

    function isExamResultValid(inputResult) {
        var i,
            len,
            sortedStudents;

        if (!Array.isArray(inputResult)) {
            return false;
        }

        if (inputResult.some(function (result) { // checks if a property score exists and if it does then checks if the score is a valid number
            return !result.hasOwnProperty('score');
        }) || inputResult.some(function (result) {
            return isNaN(result.score);
        })) {
            return false;
        }

        sortedStudents = inputResult.sort(function (a, b) {
            return a.StudentID - b.StudentID;
        });

        for (i = 0, len = sortedStudents.length; i < len - 1; i += 1) {
            if(sortedStudents[i].StudentID === sortedStudents[i+1].StudentID){
                return false;
            }
        }

        return true;
    }

    // validate student - student name is only a string, student name is 'FIRST_NAME LAST_NAME'(only two names, no more,no less!), only first letter from a name is upper case(e.g. not PEtar), only letters
    // validate titles - no empty string, no conseq. spaces(e.g. '     '), no empty spaces in the begining and end(e.g. '  title', 'title  ', '  title  ')
    // validate presentations - no presentations in the course(e.g. [])
    // validate IDs - unique ID >= 1

    return Course;
}


module.exports = solve;