import { expect } from 'chai';
import { lookupChar } from '../functions/02_CharLookup.js';

describe("lookupChar function tests", function(){
    it("should be undefined when pass invalid values", function(){
        expect(lookupChar(123, 0)).to.be.undefined;
        expect(lookupChar([], 0)).to.be.undefined;
        expect(lookupChar({}, 0)).to.be.undefined;
        expect(lookupChar(null, 0)).to.be.undefined;
        expect(lookupChar("string", {})).to.be.undefined;
        expect(lookupChar("string", 1.5)).to.be.undefined;
    })
    it("should return Incorrect index when pass negative index", function(){
        expect(lookupChar('123', -1)).to.equal("Incorrect index");
    })
    it("should return Incorrect index when pass bigger then the string length", function(){
        expect(lookupChar('123', 3)).to.equal("Incorrect index");
        expect(lookupChar('hello', 10)).to.equal("Incorrect index");
    })
    it("should return the correct char at the specified index when passing a correct value", function(){
        expect(lookupChar('super', 2)).to.equal('p');
        expect(lookupChar('javascript', 0)).to.equal('j');
        expect(lookupChar('javascript', 9)).to.equal('t');
    })
    it("should handle edge cases with empty strings", function(){
        expect(lookupChar('', 0)).to.equal('Incorrect index');
    })
})