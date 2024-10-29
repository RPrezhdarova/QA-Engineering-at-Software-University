import {expect} from 'chai';
import {foodDelivery} from '../functions/06_FoodDelivery.js';

describe("Food Delivery object tests", function(){
    describe("getCategory function tests", function(){
        it ("should return correct string for Vegan", function(){
            expect(foodDelivery.getCategory("Vegan")).to.equal("Dishes that contain no animal products.")
        })
        it ("should return correct string for Vegetarian", function(){
            expect(foodDelivery.getCategory("Vegetarian")).to.equal("Dishes that contain no meat or fish.")
        })
        it ("should return correct string for Gluten-Free", function(){
            expect(foodDelivery.getCategory("Gluten-Free")).to.equal("Dishes that contain no gluten.")
        })
        it ("should return correct string for All", function(){
            expect(foodDelivery.getCategory("All")).to.equal("All available dishes.")
        })
        it ("should throw error for invalid category", function(){
            expect(()=> foodDelivery.getCategory("incorrect")).to.throw("Invalid Category!")
        })
    })
    describe("addMenuItem function tests", function(){
        it ("should add items with valid price and return correct array length", function(){
            const menuItems = [
                {name: "Salad", price: 8},
                {name: "Soup", price: 5},
                {name: "Steak", price: 20}
            ]
            expect(foodDelivery.addMenuItem(menuItems, 10)).to.equal("There are 2 available menu items matching your criteria!")
        })
        it ("should throw error when pass invalid parameters", function(){
            const menuItems = [
                {name: "Salad", price: 8},
                {name: "Soup", price: 5},
                {name: "Steak", price: 20}
            ]
            expect(()=> foodDelivery.addMenuItem("string", 10)).to.throw("Invalid Information!")
            expect(()=> foodDelivery.addMenuItem(menuItems, "10")).to.throw("Invalid Information!")
        })
        it("should throw error for menu array with less than 1 item or maxPrice less than 5", function(){
            const menuItems = [
                {name: "Salad", price: 8},
                {name: "Soup", price: 5},
                {name: "Steak", price: 20}
            ]
            expect(()=> foodDelivery.addMenuItem([], 10)).to.throw("Invalid Information!")
            expect(()=> foodDelivery.addMenuItem(menuItems, 2)).to.throw("Invalid Information!")
        })
    })
    describe("calculateOrderCost function tests", function(){
        it ("should calculate total price without discount", function(){
            const shipping = ["standart"];
            const addOns = ["sauce", "beverage"];

            expect(foodDelivery.calculateOrderCost(shipping, addOns, false)).to.equal("You spend $4.50 for shipping and addons!")
        })
        it ("should calculate total price with discount", function(){
            const shipping = ["express"];
            const addOns = ["sauce", "beverage"];

            expect(foodDelivery.calculateOrderCost(shipping, addOns, true)).to.equal("You spend $8.07 for shipping and addons with a 15% discount!")
        })
        it("should throw error for invalid parameneters", function(){
            expect(()=> foodDelivery.calculateOrderCost("string", [], true)).throw("Invalid Information!")
            expect(()=> foodDelivery.calculateOrderCost([], "string", true)).throw("Invalid Information!")
            expect(()=> foodDelivery.calculateOrderCost([], [], "true")).throw("Invalid Information!")
        })
    })
})