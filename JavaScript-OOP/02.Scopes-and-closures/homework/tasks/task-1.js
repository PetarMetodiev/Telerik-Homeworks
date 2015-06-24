/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 * Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
	var library = (function() {
		var books = [],
			categories = [];

		// Adding books and checking them!
		function addBook(book) {
			var i,
				len,
				currentCategory;

			if ((!isISBNvalid(book.isbn)) || (!isUnique(book.isbn, 'isbn'))) {
				throw new Error();
			}

			if ((!isTitleValid(book.title)) || (!isUnique(book.title, 'title'))) {
				throw new Error();
			}

			if (!isAuthorValid(book.author)) {
				throw new Error();
			}

			currentCategory = book.category;

			if (categories.indexOf(currentCategory) < 0) {
				categories.push(currentCategory);
			}

			book.ID = books.length + 1;
			books.push(book);

			return book;
		}

		function isUnique(parameterToCheck, parameter) { //parameterToCheck - check the entered parameter; parameter - isbn or title
			var i, len;
			for (i = 0, len = books.length; i < len; i += 1) {
				if (books[i][parameter] === parameterToCheck) {
					return false;
				}
			}
			return true;
		}

		function isTitleValid(inputTitle) {
			if (inputTitle.length >= 2 && inputTitle.length <= 100) {
				return true;
			}
			return false;
		}

		function isISBNvalid(inputISBN) {
			if ((inputISBN.toString().length === 10)) {
				return true;
			}

			if ((inputISBN.toString().length === 13)) {
				return true;
			}

			if (!/^[0-9]+$/.test(inputISBN.toString())) {
				return false;
			}

			return false;
		}

		function isAuthorValid(author) {
			if (author !== '') {
				return true;
			}
			return false;
		}

		// Listing books
		function listBooks(objectWithParameter) { // objectWithParameter - has only category or author as properties
			if (objectWithParameter) {
				if (objectWithParameter.hasOwnProperty('category')) {
					return books.filter(function(book) {
						return book.category === objectWithParameter.category;
					});
				}

				if (objectWithParameter.hasOwnProperty('author')) {
					return books.filter(function(book) {
						return book.author === objectWithParameter.author;
					});
				}
			}

			return books;
		}

		function listCategories() {

			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	}());
	return library;
}
module.exports = solve;