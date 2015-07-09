function solve() {
	var module = (function () {
		var playable,
			audio,
			video,
			validator,
			CONSTANTS = {
				MIN_STRING_LENGTH: 3,
				MAX_STRING_LENGTH: 25
			};

		validator = {
			validateString: function (inputString, parameter) {
				parameter = parameter || 'Value';
				if (inputString.length < CONSTANTS.MIN_STRING_LENGTH || inputString.length > CONSTANTS.MAX_STRING_LENGTH) {
					throw new Error(parameter + ' is not within the required range!');
				}
			},
			validateNumber: function (inputNumber, parameter) {
				parameter = parameter || 'Value';
				if (isNaN(inputNumber)) {
					throw new Error(parameter + ' has to be a number');
				}
				if (inputNumber <= 0) {
					throw new Error(inputNumber + ' has to be greater than 0!');
				}
			}
		};

		playable = (function () {
			var nextId = 0,
				playable = Object.create({});

			Object.defineProperty(playable, 'init', {
				value: function (title, author) {
					this.title = title;
					this.author = author;
					this._id = ++nextId;
					return this;
				}
			});

			Object.defineProperty(playable, 'title', {
				get: function () {
					return this._title;
				},
				set: function (value) {
					validator.validateString(value, 'Playable title');
					this._title = value;
				}
			});

			Object.defineProperty(playable, 'author', {
				get: function () {
					return this._author;
				},
				set: function (value) {
					validator.validateString(value, 'Playable author');
					this._title = value;
				}
			});

			Object.defineProperty(playable, 'id', {
				get: function () {
					return this._id;
				}
			});

			Object.defineProperty(playable, 'play', {
				value: function () {
					return this._id + '. ' + this.title + ' - ' + this.author;
				}
			});

			return playable;

		} ());

		audio = (function (parent) {
			var audio = Object.create({});

			Object.defineProperty(audio, 'init', {
				value: function (title, author, length) {
					parent.init.call(this, title, author);
					this.length = length;
					return this;
				}
			});

			Object.defineProperty(audio, 'length', {
				get: function () {
					return this._length;
				},
				set: function (value) {
					validator.validateNumber(value, 'Audio length');
					this._length = value;
				}
			});

			Object.defineProperty(audio, 'play', {
				value: function () {
					return parent.play.call(this) + ' - ' + this.length;
				}
			});

			return audio;
		} (playable));

		video = (function(){
			var video = Object.create({});
			
			
			return video;
		}());

		return {
			getPlayer: function (name) {
				// returns a new player instance with the provided name
			},
			getPlaylist: function (name) {
				//returns a new playlist instance with the provided name
			},
			getAudio: function (title, author, length) {
				//returns a new audio instance with the provided title, author and length
			},
			getVideo: function (title, author, imdbRating) {
				//returns a new video instance with the provided title, author and imdbRating
			}
		}
	} ())

	return module;
}

module.exports = solve;