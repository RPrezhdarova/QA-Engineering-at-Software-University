import {expect} from "chai";
import{gameService} from "../function/gameService.js"

describe("gameService Tests", function() {

    describe("getGames()", function() {
        it("Should return a successful response with a list of games", function(){
            const response = gameService.getGames();
            expect(response.status).to.equal(200);
            expect(response.data).to.have.lengthOf(3);          
            expect(response.data[0]).to.include.keys('id', 'title', 'genre', 'year', 'developer', 'description');  
            expect(response.data[1]).to.include.keys('id', 'title', 'genre', 'year', 'developer', 'description');  
            expect(response.data[2]).to.include.keys('id', 'title', 'genre', 'year', 'developer', 'description');  
        })       
    });
  
    describe("addGame()", function() {
        it("Should add a new game successfully", function(){
            const newGame = {                                               
                id: "10", 
                title: "2The Legend of Zelda: Breath of the Wild", 
                genre: "Action-adventure2", 
                year: 3017, 
                developer: "Zintendo", 
                description: "An action-adventure game in an open world222."
            }
            const response = gameService.addGame(newGame);                      
            expect(response.status).to.equal(201);                          
            expect(response.message).to.equal("Game added successfully.");
            const games=gameService.getGames();                               
            expect(games.data).to.deep.include(newGame);            
        })
      
        it("Should return an error for invalid game data", function(){         
            const newInvalidGame = {                                           
                id: "55", 
                title: "2The Legend of Zelda: Breath of the Wild", 
                genre: "Action-adventure2", 
            }
            const response = gameService.addGame(newInvalidGame);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Game Data!");              

        })
    });
  
    describe("deleteGame()", function() {
        it("Should delete an existing game by ID", function(){                  
            const gameToDeleteId = "2";
            const response= gameService.deleteGame(gameToDeleteId);             
            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Game deleted successfully.");    
            const games=gameService.getGames().data;
            const foundGame=games.filter(games=>games.id===gameToDeleteId);       
            expect(foundGame.length).to.equal(0);
        })

        it("Should return an error if the game is not found", function(){        
            const gameToDeleteId = "200";
            const response= gameService.deleteGame(gameToDeleteId);             
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Game Not Found!");                 
        })
    });
  
    describe("updateGame()", function() {
        it("Should update an existing game with new data", function(){
            const gameIdForUpdate = "3";
            const updateGame={
                id: "3", 
                title: "New updated title", 
                genre: "Action-adventur78e2", 
                year: 3017, 
                developer: "Zi8ntendo", 
                description: "An ac8tion-adventure game in an open world222."
            }
            const response=gameService.updateGame(gameIdForUpdate, updateGame);
            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Game updated successfully.");
            const games=gameService.getGames();
            expect(games.data).to.deep.include(updateGame);
        })
  
        it("Should return an error if the game to update is not found", function(){
            const gameIdForUpdate = "105";
            const updateGame={
                id: "105", 
                title: "New updated title", 
                genre: "Action-adventur78e2", 
                year: 3017, 
                developer: "Zi8ntendo", 
                description: "An ac8tion-adventure game in an open world222."
            }
            const response=gameService.updateGame(gameIdForUpdate, updateGame);
            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Game Not Found!");
        })
  
        it("Should return an error if the new game data is invalid", function(){
            const gameIdForUpdate = "1";
            const updateGame={
                id: "1", 
                title: "New updated title", 
                genre: "Action-adventur78e2"
            }
            const response=gameService.updateGame(gameIdForUpdate, updateGame);
            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Game Data!");
        })
    });
  });
  