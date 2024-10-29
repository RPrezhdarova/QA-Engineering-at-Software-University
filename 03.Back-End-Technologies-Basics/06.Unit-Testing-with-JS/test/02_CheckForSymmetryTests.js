import {expect} from 'chai'
import {isSymmetric} from '../02_CheckForSymmetry.js'

describe("Tests for chechForSymmetryFunction", function(){
    it("should return true for symmetryc", function(){
        const result = isSymmetric([1,2,3,2,1]);
        expect(result).to.be.true;
    })
    it("should return false for non-symmetryc", function(){
        const result = isSymmetric([1,2,3,2,5]);
        expect(result).to.be.false;
    })
    it("should return true for empty array", function(){
        const result = isSymmetric([]);
        expect(result).to.be.true;
    })
    it("should return false for non-array", function(){
        const result = isSymmetric('this is not array');
        expect(result).to.be.false;
    })
    it("should return false for non-number elements", function(){
        const result = isSymmetric([1, '1']);
        expect(result).to.be.false;
    })
    it("should return true for syngel element", function(){
        const result = isSymmetric([1]);
        expect(result).to.be.true;
    })
})