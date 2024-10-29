import { expect } from 'chai'
import { sum } from '../functionESM.mjs'

describe('Sum funtion tests', function(){
    it("sum single number", function(){
        expect(sum([1])).to.equal(1);
    })
})
