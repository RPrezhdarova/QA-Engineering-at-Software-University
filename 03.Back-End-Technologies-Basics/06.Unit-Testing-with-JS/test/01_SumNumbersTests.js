import {expect} from 'chai'
import {sum} from '../01_SumNumbers.js'

describe("Sum function tests", function(){
    it("should return the sum of an array of numbers", function(){
        //Arrange
        let testData = [1, 2, 3]
        let result;

        //Act
        result = sum(testData);

        //Assert
        expect(result).to.equal(6)
    })
    it("should return the sum of an array as string", function(){
        //Arrange
        let testData = ['1', '2', '3']
        let result;

        //Act
        result = sum(testData);

        //Assert
        expect(result).to.equal(6)
    })
    it("should return 0 when pass array with 0 elements", function(){
        //Arrange
        let testData = []
        let result;

        //Act
        result = sum(testData);

        //Assert
        expect(result).to.equal(0)
    })
    it("should return correct sum when pass array with negative numbers", function(){
        //Arrange
        let testData = [-1, -6, -10]
        let result;

        //Act
        result = sum(testData);

        //Assert
        expect(result).to.equal(-17)
    })
    it("should return correct sum when pass array with mixed input", function(){
        //Arrange
        let testData = [1, '6', 3]
        let result;

        //Act
        result = sum(testData);

        //Assert
        expect(result).to.equal(10)
    })
    it("should return NaN when pass array with chars as input", function(){
        //Arrange
        let testData = ['a', 'b', 'c']
        let result;

        //Act
        result = sum(testData);

        //Assert
        expect(result).to.be.NaN
    })
})
