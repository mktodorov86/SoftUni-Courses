import { expect } from "chai";
import {movieService} from "../functions/movieService.js"
describe("Alternative Tests for movieService", function () {
    
    describe("getMovies()", function () {
        it("should return status 200 and an array of movies with expected properties", function () {
            const { status, data } = movieService.getMovies();
            
            expect(status).to.equal(200);
            expect(data).to.be.an("array").with.lengthOf(3);
            expect(data[0]).to.have.keys(["id", "name", "genre", "year", "director", "rating", "duration", "language", "desc"]);
            
            // Additional checks for array structure without iterating over each movie
            expect(data.every(movie => movie.id && movie.name && movie.genre)).to.be.true;
        });
    });

    describe("addMovie()", function () {
        it("should add a valid movie and confirm presence in the list", function () {
            const newMovie = {
                id: "4",
                name: "Dune",
                genre: "Sci-Fi",
                year: 2021,
                director: "Denis Villeneuve",
                rating: 8.2,
                duration: 155,
                language: "English",
                desc: "A noble family becomes embroiled in a war for control over the galaxy's most valuable asset."
            };
            const result = movieService.addMovie(newMovie);

            expect(result.status).to.equal(201);
            expect(result.message).to.equal("Movie added successfully.");
            expect(movieService.movies.some(movie => movie.id === "4" && movie.name === "Dune")).to.be.true;
        });

        it("should return status 400 and an error message when data is invalid", function () {
            const invalidMovie = { id: "5", name: "Invalid Movie" }; // Missing other required fields
            const result = movieService.addMovie(invalidMovie);

            expect(result.status).to.equal(400);
            expect(result.error).to.equal("Invalid Movie Data!");
        });
    });

    describe("deleteMovie()", function () {
        it("should delete a movie by id and confirm its removal", function () {
            const result = movieService.deleteMovie("4"); // Assuming id "4" exists after addMovie test

            expect(result.status).to.equal(200);
            expect(result.message).to.equal("Movie deleted successfully.");
            expect(movieService.movies.some(movie => movie.id === "4")).to.be.false;
        });

        it("should return status 404 and an error message if movie id is not found", function () {
            const result = movieService.deleteMovie("999"); // Non-existent movie id

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Movie Not Found!");
        });
    });

    describe("updateMovie()", function () {
        it("should update an existing movie's data and confirm changes", function () {
            const updatedMovie = {
                id: "1",
                name: "Inception Updated",
                genre: "Sci-Fi",
                year: 2010,
                director: "Christopher Nolan",
                rating: 8.9,
                duration: 148,
                language: "English",
                desc: "Updated description."
            };
            const result = movieService.updateMovie("Inception", updatedMovie);

            expect(result.status).to.equal(200);
            expect(result.message).to.equal("Movie updated successfully.");
            const movie = movieService.movies.find(movie => movie.id === "1");
            expect(movie).to.have.property("name", "Inception Updated");
        });

        it("should return status 404 and an error message if movie is not found", function () {
            const nonExistentMovie = {
                id: "999",
                name: "Non Existent Movie",
                genre: "Fantasy",
                year: 2000,
                director: "Unknown Director",
                rating: 5.0,
                duration: 120,
                language: "English",
                desc: "Non existent movie description."
            };
            const result = movieService.updateMovie("Non Existent Movie", nonExistentMovie);

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Movie Not Found!");
        });

        it("should return status 400 and an error message if new movie data is invalid", function () {
            const invalidUpdate = {
                id: "1",
                name: "", // Invalid name
                genre: "Sci-Fi",
                year: 2010,
                director: "Christopher Nolan",
                rating: 8.8,
                duration: 148,
                language: "English",
                desc: "Invalid update test."
            };
            const result = movieService.updateMovie("Inception Updated", invalidUpdate);

            expect(result.status).to.equal(400);
            expect(result.error).to.equal("Invalid Movie Data!");
        });
    });
});