import { expect } from "chai";
import { gameService } from "../function/gameService.js";

describe("gameService Tests", function() {

    describe("getGames()", function() {
        it("should return a successful response with a list of games", function() {
            const response = gameService.getGames();
            expect(response.status).to.equal(200);
            expect(response.data).to.be.an('array').that.has.lengthOf(3);
            expect(response.data[0]).to.include.keys('id', 'title', 'genre', 'year', 'developer', 'description');
        });
    });

    describe("addGame()", function() {
        it("should add a new game successfully", function() {
            const newGame = { id: "4", title: "Dark Souls III", genre: "Action RPG", year: 2016, developer: "FromSoftware", description: "A challenging action RPG." };
            const response = gameService.addGame(newGame);
            expect(response.status).to.equal(201);
            expect(response.message).to.equal("Game added successfully.");
            expect(gameService.games).to.include.deep.members([newGame]);
        });

        it("should return an error for invalid game data", function() {
            const invalidGame = { id: "5", title: "Incomplete Game", genre: "Adventure" }; // Missing required fields
            const response = gameService.addGame(invalidGame);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Game Data!");
        });
    });

    describe("deleteGame()", function() {
        it("should delete an existing game by ID", function() {
            const response = gameService.deleteGame("1"); // Assuming the game with ID "1" exists
            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Game deleted successfully.");
            expect(gameService.games).to.not.deep.include({ id: "1" });
        });

        it("should return an error if the game is not found", function() {
            const response = gameService.deleteGame("999"); // Non-existent ID
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Game Not Found!");
        });
    });

    describe("updateGame()", function() {
        it("should update an existing game with new data", function() {
            const updatedGame = { id: "2", title: "God of War: Ragnarok", genre: "Action-adventure", year: 2022, developer: "Santa Monica Studio", description: "The sequel to the original." };
            const response = gameService.updateGame("2", updatedGame); // Update game with ID "2"
            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Game updated successfully.");
            expect(gameService.games).to.include.deep.members([updatedGame]);
        });

        it("should return an error if the game to update is not found", function() {
            const response = gameService.updateGame("999", { id: "999", title: "Non-existent Game", genre: "Genre", year: 2020, developer: "Dev", description: "A game that doesn't exist." });
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Game Not Found!");
        });

        it("should return an error if the new game data is invalid", function() {
            const response = gameService.updateGame("2", { id: "2", title: "Invalid Update", genre: "Genre" }); // Incomplete data
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Game Data!");
        });
    });
});