import {expect} from "chai";
import{bookService} from "../functions/bookService.js"



describe("Book Service Tests", function() {

    describe("getBooks()", function() {
        it("Should return a status 200 and an array of books", function(){
            const response=bookService.getBooks();
            expect(response.status).to.equal(200);
            expect(response.data).to.be.an('array').that.has.lengthOf(3);
            expect(response.data[0]).to.include.keys('id', 'title', 'author', 'year', 'genre')
            expect(response.data[1]).to.include.keys('id', 'title', 'author', 'year', 'genre')
            expect(response.data[2]).to.include.keys('id', 'title', 'author', 'year', 'genre')
        })
    });

    describe("addBook()", function() {
        it("Should add a new book successfully", function(){
            const newBook = {
                id: "4", 
                title: "TestBook", 
                author: "TestAuthor", 
                year: 1989, 
                genre: "TestGenre"
            }
            const response=bookService.addBook(newBook);
            expect(response.status).to.equal(201);
            expect(response.message).to.equal("Book added successfully.");
            const books=bookService.getBooks();
            expect(books.data).to.deep.include(newBook);
            expect(books.data[3]).to.include.keys('id', 'title', 'author', 'year', 'genre')

        })
        
        it("Should return status 400 when adding a book with missing fields", function(){
            const invalidBook = {
                id: "6", 
                title: "Invalid Book", 
                author: "Author"}

            const response=bookService.addBook(invalidBook);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Book Data!");
        })

        it("Should return status 400 when adding a book with invalid fields", function(){
            const invalidBook = {
                id: "6", 
                title: "TestBook", 
                author: "", 
                year: "1989", 
                genre: 2
            }

            const response=bookService.addBook(invalidBook);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Book Data!");
        })

        it("Should return status 400 when updating with invalid data types", function() {
            const updatedBook = {
                id: 2, 
                title: "Updated Book", 
                author: "Author", 
                year: "", 
                genre: 2 };
            const response = bookService.updateBook("2", updatedBook);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Book Data!");
        })
    });

    describe("deleteBook()", function() {
        it("Should delete a book by id successfully", function(){           // Test: Should delete a book by id successfully
       
        const addABook = {                                                  // 1. Add a book and then delete it by its ID.
            id: "5", 
            title: "TestBook", 
            author: "TestAuthor", 
            year: 1989, 
            genre: "TestGenre"
        }
        const addBook=bookService.addBook(addABook);
        
        const bookIdToBeDeleted = "5";
            const response = bookService.deleteBook(bookIdToBeDeleted);
            expect(response.status).to.equal(200);                                  // 2. Verify the response status is 200 and the success message is correct.
            expect(response.message).to.equal("Book deleted successfully.");

            // 3. Ensure the book count returns the sum of the initial count of the books and the count of the added books from the tests
            const books = bookService.getBooks().data;
            const foundBooks=books.filter(books=>books.id === bookIdToBeDeleted);
            expect(foundBooks.length).to.equal(0);
            const filteredBooks=books.filter(books=>books.id !== bookIdToBeDeleted);
            expect(filteredBooks.length).to.equal(4);

        })
        it("Should return status 404 when deleting a book with a non-existent id", function(){
            const bookIdToBeDeleted = "11";
            const response = bookService.deleteBook(bookIdToBeDeleted);
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Book Not Found!");
        })
        
    });

    describe("updateBook()", function() {
        it("Should update a book successfully", function(){
            const updatedBook = {
            id: "3", 
            title: "Updated The Great Gatsby", 
            author: "Updated F. Scott Fitzgerald", 
            year: 1925, 
            genre: "Classic"
            }
            const response = bookService.updateBook("3", updatedBook);
            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Book updated successfully.");
            const books = bookService.getBooks();
            expect(books.data).to.deep.include(updatedBook);

            const updatedBookFromService = bookService.books.find(book => book.id === "3");
            expect(updatedBookFromService).to.deep.equal(updatedBook);

        })
        it("Should return status 404 when updating a non-existent book", function(){
            const updatedBook = {
            id: "3", 
            title: "Updated The Great Gatsby", 
            author: "Updated F. Scott Fitzgerald", 
            year: 1925, 
            genre: "Classic"
            }
            const response = bookService.updateBook("30", updatedBook);
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Book Not Found!");
        })
        it("Should return status 400 when updating with incomplete book data", function(){
            const updatedBook = {
            id: "1", 
            title: "Updated The Great Gatsby", 
            }
            const response = bookService.updateBook("1", updatedBook);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Book Data!");
        })
    });
});
