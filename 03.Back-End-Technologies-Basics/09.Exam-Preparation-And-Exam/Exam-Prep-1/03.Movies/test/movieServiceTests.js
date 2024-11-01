import {expect} from "chai";
import {movieService} from "../functions/movieService.js"

describe("movieService Tests", function () {

    describe("getMovies()", function () {

        it("Should return all movies with status 200", function(){                                                                              //// Test: Should return all movies with status 200
            const response = movieService.getMovies();
            expect(response.status).to.equal(200);                                                                                              // 1. Check if the response status is 200.
            expect(response.data).to.be.an('array').that.has.lengthOf(3);                                                                         // 2. Ensure the data is an array with a length of 3.
            expect(response.data[0]).to.include.keys('id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc')       // 3. Verify the first item contains the required keys: 'id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc'.
            expect(response.data[1]).to.include.keys('id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc')       // 3. Verify the second item contains the required keys: 'id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc'.
            expect(response.data[2]).to.include.keys('id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc')       // 3. Verify the third item contains the required keys: 'id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc'.
        })
    });
  
    describe("addMovie()", function () {
        it("Should successfully add a new movie", function(){                                                                                        // Test: Should successfully add a new movie
         const newMovie = {                                                                                                                         // 1. Create a new movie object with valid data.
            id: "10",
            name: "Inception10",
            genre: "Sci-Fi10",
            year: 2019,
            director: "Christopher Nolan12",
            rating: 9.8,
            duration: 155,
            language: "English",
            desc: "A second thief who steals corporate secrets through the use of dream-sharing technology."
        }

        const response = movieService.addMovie(newMovie);
        expect(response.status).to.equal(201);                                                                                                      // 2. Check if the response status is 201 and the success message is correct.
        expect(response.message).to.equal("Movie added successfully.");                                                                             // 3. Verify that the newly added movie is present in the movie list.
        const movies = movieService.getMovies();
        expect(movies.data).to.deep.include(newMovie);
    })      

        it("Should return an error for invalid movie data", function(){                                                                                 // Test: Should return an error for invalid movie data
         const newMovie = {                                                                                                                          // 1. Create a movie object with incomplete or invalid data.
            id: "10",
            name: "Inception10",
            genre: "Sci-Fi10",
        }

        const response = movieService.addMovie(newMovie);                                                                                           // 2. Check if the response status is 400 and the error message is correct.      
        expect(response.status).to.equal(400);                                                                                                      
        expect(response.error).to.equal("Invalid Movie Data!");                                                                             
        }) 
    });
  
    describe('deleteMovie()', function () {
        it("Should delete a movie by id successfully", function(){                                                           
            const movieIdtoBeDeleted="1";
            const response = movieService.deleteMovie(movieIdtoBeDeleted);
            expect(response.status).to.equal(200);   
            expect(response.message).to.equal("Movie deleted successfully.");   
            const movies = movieService.getMovies().data;
            const foundMovies=movies.filter(movies=>movies.id === movieIdtoBeDeleted);
            expect(foundMovies.length).to.equal(0);
        }) 
        it("Should return 404 for a non-existent movie id", function(){                                                           
            const movieIdtoBeDeleted="100";
            const response = movieService.deleteMovie(movieIdtoBeDeleted);
            expect(response.status).to.equal(404);   
            expect(response.error).to.equal("Movie Not Found!");   
        }) 
    });
  
    describe("updateMovie()", function () {
        it("Should update an existing movie successfully", function(){
         const updatedMovie = {
            id: "2",
            name: "The Matrix-new Name",
            genre: "Action",
            year: 1999,
            director: "Lana Wachowski, Lilly Wachowski",
            rating: 8.7,
            duration: 136,
            language: "English",
            desc: "A computer hacker learns about the true nature of reality and his role in the war against its controllers."
        }
        const response = movieService.updateMovie("The Matrix", updatedMovie);
        expect(response.status).to.equal(200);
        expect(response.message).to.equal("Movie updated successfully."); 
        const movies = movieService.getMovies();
        expect(movies.data).to.deep.include(updatedMovie);
    })

        it("Should return an error if the movie to update does not exist", function(){
         const updatedMovie = {
            id: "2",
            name: "The Matrix-new Name",
            genre: "Action",
            year: 1999,
            director: "Lana Wachowski, Lilly Wachowski",
            rating: 8.7,
            duration: 136,
            language: "English",
            desc: "A computer hacker learns about the true nature of reality and his role in the war against its controllers."
            }
            const response = movieService.updateMovie("No such Name", updatedMovie);
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Movie Not Found!"); 

   })
   it("Should return an error if the new movie data is invalid", function(){
    const updatedMovie = {
        id: "1",
            name: "Inception234",
            genre: "Sci-Fi",
            year: 2010
    
    }
    const response = movieService.updateMovie("Interstellar", updatedMovie);
    expect(response.status).to.equal(400);
    expect(response.error).to.equal("Invalid Movie Data!"); 

      })
    });
  });