import {expect} from 'chai'
import {rgbToHexColor} from '../03_RGBtoHex.js'

describe("rgbToHex function tests", function(){
    it("should return correct hex for valid RGB", function(){
        const result = rgbToHexColor(255, 142, 144);
        expect(result).to.equal('#FF8E90');
    })
    it("should return correct hex with lower boundary", function(){
        const result = rgbToHexColor(0, 0, 0);
        expect(result).to.equal('#000000');
    })
    it("should return correct hex with upper boundary", function(){
        const result = rgbToHexColor(255, 255, 255);
        expect(result).to.equal('#FFFFFF');
    })
    it("should return undefined for negative number", function(){
        const result = rgbToHexColor(-1, 255, 255);
        expect(result).to.be.undefined;
    })
    it("should return undefined for bigger then 255 number", function(){
        const result = rgbToHexColor(256, 255, 255);
        expect(result).to.be.undefined;
    })
    it("should return undefined for decimal red", function(){
        const result = rgbToHexColor(12.5, 122, 255);
        expect(result).to.be.undefined;
    })
    it("should return undefined for decimal blue", function(){
        const result = rgbToHexColor(255, 12.5, 255);
        expect(result).to.be.undefined;
    })
    it("should return undefined for decimal green", function(){
        const result = rgbToHexColor(255, 145, 12.5);
        expect(result).to.be.undefined;
    })
    it("should return undefined for string", function(){
        const result = rgbToHexColor('a', 'b', 'c');
        expect(result).to.be.undefined;
    })
    it("should return undefined for string", function(){
        const result = rgbToHexColor('a', 'b', 'c');
        expect(result).to.be.undefined;
    })
})