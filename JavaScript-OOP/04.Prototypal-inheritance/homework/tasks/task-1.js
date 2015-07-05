/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * method removeAttribute(attribute)
 * throw Error if attribute does not exist in the domElement
 */


/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/


function solve() {
	var domElement = (function() {
		var domElement = {
			init: function(type) {
				this.type = type;
				this.attributes = [];
				this.children = [];
				this._content = '';
				this.contentAddedThroughAppendChild = false;
				return this;
			},
			appendChild: function(child) {

				this.children.push(child);
				this.contentAddedThroughAppendChild = true;

				if (typeof child !== 'string') {
					child.parent = this;
				}

				return this;
			},
			addAttribute: function(name, value) {
				this.name = name;
				this.value = value;

				pushToAttributesArray.call(this, name, value);

				return this;
			},
			removeAttribute: function(attribute) {
				if (!attributeExists.call(this, attribute)) {
					throw new Error('Trying to remove non-existant attribute');
				}

				this.attributes.splice(getIndexOfObject.call(this, attribute), 1);

				return this;
			},
			get innerHTML() {

				var result = '';
				result += '<' + this.type + getAttributes.call(this) + '>';

				result += this.content;

				if (this.children.length) {
					result += getChildrenContent.call(this);
				}

				result += '</' + this.type + '>';
				return result;
			}
		};

		Object.defineProperty(domElement, 'type', {
			get: function() {
				return this._type;
			},
			set: function(inputName) {
				if (typeof inputName !== 'string' || !/^[A-z0-9]+$/g.test(inputName)) {
					throw new Error('Invalid dom element name!');
				}
				this._type = inputName;
			}
		});

		Object.defineProperty(domElement, 'name', {
			get: function() {
				return this._name;
			},
			set: function(value) {
				if (!/^[A-z0-9\-]+$/g.test(value)) {
					throw new Error('Invalid name');
				}
				this._name = value;
			}
		});

		Object.defineProperty(domElement, 'attributes', {
			get: function() {
				return this._attributes;
			},
			set: function(value) {
				this._attributes = value;
			}
		});

		Object.defineProperty(domElement, 'content', {
			get: function() {
				return this._content || '';
			},
			set: function(value) {
				if (this.addingThroughAppendChild) {
					this._content = value;
					this.addingThroughAppendChild = false;
				}
				if (!this.contentAddedThroughAppendChild) {
					this._content = value;
				}
			},
			enumerable: true
		});

		Object.defineProperty(domElement, 'children', {
			get: function() {
				return this._children;
			},
			set: function(value) {
				this._children = value;
			}
		});

		Object.defineProperty(domElement, 'parent', {
			get: function() {
				return this._parent;
			},
			set: function(value) {
				this._parent = value;
			}
		});

		Object.defineProperty(domElement, 'alreadyCovered', {
			get: function() {
				return this._alreadyCovered;
			},
			set: function(value) {
				this._alreadyCovered = value;
			}
		});

		function pushToAttributesArray(name, value) {
			if (attributeExists.call(this, name)) {
				this.attributes[getIndexOfObject.call(this, name)] = {
					name: name,
					value: value
				};
			} else {
				this.attributes.push({
					name: name,
					value: value
				});
			}
		}

		function attributeExists(attributeName) {
			var i,
				len;

			for (i = 0, len = this.attributes.length; i < len; i += 1) {
				if (this.attributes[i].name === attributeName) {
					return true;
				}
			}
			return false;
		}

		function getIndexOfObject(objName) {
			var i,
				len,
				index = -1;

			for (i = 0, len = this.attributes.length; i < len; i += 1) {
				if (this.attributes[i].name === objName) {
					index = i;
					break;
				}
			}

			return index;
		}

		function getAttributes() {
			var result = this.attributes.length ? ' ' : '',
				arrayResult = this.attributes.slice(),
				i,
				len;

			arrayResult = arrayResult.sort(function(a, b) {
				if (a.name > b.name) {
					return 1;
				}
				if (a.name < b.name) {
					return -1;
				}
				return 0;
			});

			for (i = 0, len = arrayResult.length; i < len; i += 1) {
				result += arrayResult[i].name + '="' + arrayResult[i].value + '"';
				if (i < len - 1) {
					result += ' ';
				}
			}

			return result;
		}

		function getChildrenContent() {

			var result = '',
				i,
				len;

			for (i = 0, len = this.children.length; i < len; i += 1) {

				if (typeof this.children[i] === 'string') {
					result += this.children[i];
				} else {
					result += this.children[i].innerHTML;
				}

				// if (!this.alreadyCovered) {
				// result += this.children[i].innerHTML;
				// this.children[i].alreadyCovered = true;
				// }
			}

			return result;
		}

		return domElement;
	}());

	return domElement;
}

module.exports = solve;