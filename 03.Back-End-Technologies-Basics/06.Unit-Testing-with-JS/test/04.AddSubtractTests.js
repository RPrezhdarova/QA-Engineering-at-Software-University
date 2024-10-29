import {expect} from 'chai'
import {createCalculator} from '../04_AddSubtract.js'

describe("Caldulator function tests", function(){
    it("should return correct object of calculations", function(){
        const result = createCalculator(5);
        expect(result).to.equal(0);

    })
})