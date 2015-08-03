/* globals $ */

/*

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed
*/

module.exports = function () {

    return function (element, contents) {
        var root,
            divElement,
            fragment,
            i,
            len,
            divToAdd;

        if (!arguments.length) {
            throw new Error('No elements passed!');
        }

        if (typeof(element) !== 'string' && !(element instanceof HTMLElement)) {
            throw new Error('Invalid element!');
        }

        if (typeof(element) === 'string') {
            root = document.getElementById(element);
        } else {
            root = element;
        }

        contents.some(function (content) {
            if (typeof (content) !== 'string' && typeof(content) !== 'number') {
                throw new Error('Content should be a string or number!');
            }
        })

        root.innerHTML = '';

        divElement = document.createElement('div');
        fragment = document.createDocumentFragment();

        for (i = 0, len = contents.length; i < len; i += 1) {
            divToAdd = divElement.cloneNode(true);
            divToAdd.innerHTML = contents[i];
            fragment.appendChild(divToAdd);
        }

        root.appendChild(fragment);
    };
};