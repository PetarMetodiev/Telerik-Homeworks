var Course = (function () {
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

        if (inputResult.some(function (result) {
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
} ());

var validTitles = [
    'Modules and Patterns',
    'Ofcourse, this is a valid title!',
    'No errors hIr.',
    'Moar taitles',
    'Businessmen arrested for harassment of rockers',
    'Miners handed cabbages to the delight of children',
    'Dealer stole Moskvitch',
    'Shepherds huddle',
    'Retired Officers rally',
    'Moulds detonate tunnel',
    'sailors furious'
], validNames = [
        'Pesho',
        'Notaname',
        'Johny',
        'Marulq',
        'Keremidena',
        'Samomidena',
        'Medlar',
        'Yglomer',
        'Elegant',
        'Analogical',
        'Bolsheviks',
        'Reddish',
        'Arbitrage',
        'Toyed',
        'Willfully',
        'Transcribing'
    ];

function getValidTitle() {
    return validTitles[(Math.random() * validTitles.length) | 0];
}

function getValidName() {
    return validNames[(Math.random() * validNames.length) | 0];
}

function checkStudentList(list1, list2) {
    if (list1.length !== list2.length)
        return false;

    function compare(a, b) {
        return a.id - b.id;
    }

    list1.sort(compare);
    list2.sort(compare);

    for (var i in list1) {
        if (list1[i].id !== list2[i].id)
            return false;
        if (list1[i].firstname !== list2[i].firstname)
            return false;
        if (list1[i].lastname !== list2[i].lastname)
            return false;
    }
    return true;
}

// TESTS //

var jsoop = Object.create(Course)
    .init(getValidTitle(), [getValidTitle()]);
jsoop.addStudent(getValidName() + ' ' + getValidName());
jsoop.addStudent(getValidName() + ' ' + getValidName());


jsoop.pushExamResults([{ StudentID: 1, score: 'asd' }, { StudentID: 2, score: 4 }]);