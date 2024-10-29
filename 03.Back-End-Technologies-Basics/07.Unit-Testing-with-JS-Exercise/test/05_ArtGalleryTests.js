import {expect} from 'chai';
import {artGallery} from '../functions/05_ArtGallery.js'

describe("artGallery object tests", function(){
    describe("add artwork function tests", function(){
        it("should throw error for invalid title or artist", function(){
            expect(() => artGallery.addArtwork(123, "30 x 40", "Van Gogh")).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork("Title", "30 x 40", 123)).to.throw("Invalid Information!")
        })
        it("should throw error for invalid dimension, when pass invalid dimension", function(){
            expect(() => artGallery.addArtwork("Title", "string", "Van Gogh")).to.throw("Invalid Dimensions!")
            expect(() => artGallery.addArtwork("Title", "30by30", "Van Gogh")).to.throw("Invalid Dimensions!")
        })
        it("should throw error for invalid artist, when pass invalid artist", function(){
            expect(() => artGallery.addArtwork("Title", "30 x 40", "Test Gogh")).to.throw("This artist is not allowed in the gallery!")
            expect(() => artGallery.addArtwork("Title2", "30 x 40", "Van Artist")).to.throw("This artist is not allowed in the gallery!")
        })
        it("should return correct message when pass correct data", function(){
            expect(artGallery.addArtwork("Correct data", "30 x 40", "Van Gogh")).to.equal("Artwork added successfully: 'Correct data' by Van Gogh with dimensions 30 x 40.")
        })
    })
    describe("calculate cost function tests", function(){
        it("should throw error message when pass invalid parameters", function(){
            expect(()=> artGallery.calculateCosts("100", 100, true)).to.throw("Invalid Information!")
            expect(()=> artGallery.calculateCosts("100", -100, true)).to.throw("Invalid Information!")
            expect(()=> artGallery.calculateCosts(100, "100", true)).to.throw("Invalid Information!")
            expect(()=> artGallery.calculateCosts(-100, "100", true)).to.throw("Invalid Information!")
            expect(()=> artGallery.calculateCosts(100, 100, "yes")).to.throw("Invalid Information!")
        })
        it("should calculate total cost without discount", function(){
            expect(artGallery.calculateCosts(100, 200, false)).to.equal("Exhibition and insurance costs are 300$.")
        })
        it("should calculate total cost with discount", function(){
            expect(artGallery.calculateCosts(100, 200, true)).to.equal("Exhibition and insurance costs are 270$, reduced by 10% with the help of a donation from your sponsor.")
        })
    })
    describe("organizeExhibits function tests", function(){
        it("should throw error when pass invalid date", function(){
            expect(()=> artGallery.organizeExhibits("10", 2)).to.throw("Invalid Information!")
            expect(()=> artGallery.organizeExhibits("10", -2)).to.throw("Invalid Information!")
            expect(()=> artGallery.organizeExhibits(10, "2")).to.throw("Invalid Information!")
            expect(()=> artGallery.organizeExhibits(-10, "2")).to.throw("Invalid Information!")
        })
        it("should return correct message when artworks is less then 5", function(){
            expect(artGallery.organizeExhibits(10, 3)).to.equal("There are only 3 artworks in each display space, you can add more artworks.")
        })
        it("should return correct message when artworks is more then 5", function(){
            expect(artGallery.organizeExhibits(20, 4)).to.equal("You have 4 display spaces with 5 artworks in each space.")
        })
    })
})