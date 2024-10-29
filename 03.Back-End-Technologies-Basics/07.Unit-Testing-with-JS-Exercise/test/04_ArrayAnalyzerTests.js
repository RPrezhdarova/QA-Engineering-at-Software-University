import {expect} from 'chai';
import {analyzeArray} from '../functions/04_ArrayAnalyzer.js';

describe("AnalyzeArray function tests", function(){
    it ("should return undefined if the input is not an array", function(){
        expect(analyzeArray(123)).to.be.undefined;
        expect(analyzeArray('123')).to.be.undefined;
        expect(analyzeArray({})).to.be.undefined;
        expect(analyzeArray(null)).to.be.undefined;
    })
    it("should return undefined when pass empty array", function(){
        expect(analyzeArray([])).to.be.undefined;
    })
    it("should return undefined when pass array with no numbers", function(){
        expect(analyzeArray(["string"])).to.be.undefined;
        expect(analyzeArray(["string", 5])).to.be.undefined;
        expect(analyzeArray([5, "string"])).to.be.undefined;
    })
    it("should return correct object when pass correct array", function(){
        expect(analyzeArray([1, 2, 3, 4, 5])).to.deep.equal({min: 1, max: 5, length: 5})
        expect(analyzeArray([-1, -2, -3, -4, -5])).to.deep.equal({min: -5, max: -1, length: 5})
    })  
    it("should return correct object when pass array with single element", function(){
        expect(analyzeArray([1])).to.deep.equal({min: 1, max: 1, length: 1})
    })  
    it("should return correct object when pass array with equal elements", function(){
        expect(analyzeArray([1, 1, 1])).to.deep.equal({min: 1, max: 1, length: 3})
    })  
})