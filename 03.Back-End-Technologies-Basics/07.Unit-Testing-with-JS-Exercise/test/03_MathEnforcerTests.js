import {expect} from 'chai';
import{mathEnforcer} from '../functions/03_MathEnforcer.js';

describe("Math Enforcer object tests", function(){
    describe("addFive function tests", function(){
        it("should return undefined when pass non number input", function(){
            expect(mathEnforcer.addFive('5')).to.be.undefined;
            expect(mathEnforcer.addFive([])).to.be.undefined;
            expect(mathEnforcer.addFive({})).to.be.undefined;
            expect(mathEnforcer.addFive(null)).to.be.undefined;
        })
        it("should return correct number when pass valid number", function(){
            expect(mathEnforcer.addFive(5)).to.equal(10);
        })
        it("should return correct number when pass negative number", function(){
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        })
        it("should return correct number when pass floating point", function(){
            expect(mathEnforcer.addFive(5.5)).to.closeTo(10.5, 0.01);
        })
    });
    describe("substractTen function tests", function(){
        it("should return undefined when pass incorrect input", function(){
            expect(mathEnforcer.subtractTen('10')).to.be.undefined;
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
            expect(mathEnforcer.subtractTen(null)).to.be.undefined;
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined;
        })
        it("should return correct result when pass positive number", function(){
            expect(mathEnforcer.subtractTen(10)).to.equal(0);
            expect(mathEnforcer.subtractTen(20)).to.equal(10);
        })
        it("should return correct number when pass negative number", function(){
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        })
        it("should return correct number when pass floating point", function(){
            expect(mathEnforcer.subtractTen(10.5)).to.closeTo(0.5, 0.01);
        })

    });
    describe("sum function tests", function(){
        it("should return undefined when pass no number parameters", function(){
            expect(mathEnforcer.sum('10', 5)).to.be.undefined;
            expect(mathEnforcer.sum([], 5)).to.be.undefined;
            expect(mathEnforcer.sum({}, 5)).to.be.undefined;
            expect(mathEnforcer.sum(null, 5)).to.be.undefined;
            expect(mathEnforcer.sum(5, undefined)).to.be.undefined;
            expect(mathEnforcer.sum(5, [])).to.be.undefined;
            expect(mathEnforcer.sum(5, {})).to.be.undefined;
            expect(mathEnforcer.sum(5, null)).to.be.undefined;
            expect(mathEnforcer.sum([], null)).to.be.undefined;
        })
        it("should return correct result when pass positive numbers", function(){
            expect(mathEnforcer.sum(5, 5)).to.equal(10);
            expect(mathEnforcer.sum(20, 5)).to.equal(25);
        })
        it("should return correct number when pass negative numbers", function(){
            expect(mathEnforcer.sum(-5, -10)).to.equal(-15);
        })
        it("should return correct number when pass negative and positive numbers", function(){
            expect(mathEnforcer.sum(-5, 10)).to.equal(5);
        })
        it("should return correct number when pass floating points", function(){
            expect(mathEnforcer.sum(10.5, 1.1)).to.closeTo(11.6, 0.01);
        })
    })
})