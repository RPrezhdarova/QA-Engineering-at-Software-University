import { expect } from 'chai';
import { isOddOrEven } from '../functions/01_IsOddOrEven.js';

describe("isOddOrEven function tests", function(){
    it("should return undefined when input is not a string", function(){

        expect(isOddOrEven(123)).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven(null)).to.be.undefined;
        expect(isOddOrEven(undefined)).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
    })
    it("should return even when the string lenght is even", function(){

        expect(isOddOrEven("four")).to.equal("even");
        expect(isOddOrEven("fourfour")).to.equal("even");
        
    })
    it("should return odd when the string lenght is odd", function(){

        expect(isOddOrEven("one")).to.equal("odd");
        expect(isOddOrEven("oneonee")).to.equal("odd");
        
    })
    it("should return correct value when pass different input", function(){

        expect(isOddOrEven("")).to.equal("even");
        expect(isOddOrEven("even")).to.equal("even");
        expect(isOddOrEven("odd")).to.equal("odd");
        expect(isOddOrEven(null)).to.be.undefined;
        
    })
})

