const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let petName = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    describe("authentication", () => {
        test("Registration with valid data", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text()='Register']");
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random()*10000);
            user.email= `user_${random}@gmail.com`;

            //Act
            await page.fill("//input[@id='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.fill("//input[@id='repeatPassword']", user.confirmPass);

            await page.click("//button[@type='submit']");

            //Assert
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();
            expect(page.url()).toBe(host + "/");
        })
        test("Login with valid data", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text()='Login']");
            await page.waitForSelector("//form");

            //Act
            await page.fill("//input[@id='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[@type='submit']");

            //Assert
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();
            expect(page.url()).toBe(host + "/");
        })

        test("Logout from the application", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text()='Login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@id='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[@type='submit']");
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();

            //Act
            await page.click("//a[text()='Logout']");

            //Assert
            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            expect(page.url()).toBe(host + "/");
        })
    })

    describe("navbar", () => {
        test("Navigation to logged in users", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text()='Login']");
            
            //Act            
            await page.waitForSelector("//form");
            await page.fill("//input[@id='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[@type='submit']");           

            //Assert
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[@href='/catalog']")).toBeVisible();
            await expect(page.locator("//a[@href='/create']")).toBeVisible();
            await expect(page.locator("//a[@href='/logout']")).toBeVisible();

            await expect(page.locator("//a[@href='/login']")).toBeHidden();
            await expect(page.locator("//a[@href='/register']")).toBeHidden();
        })

        test("Navigation for guest users", async()=>{
            //Arrange & Act
            await page.goto(host);           

            //Assert
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[@href='/catalog']")).toBeVisible();            
            await expect(page.locator("//a[@href='/login']")).toBeVisible();
            await expect(page.locator("//a[@href='/register']")).toBeVisible();

            await expect(page.locator("//a[@href='/create']")).toBeHidden();
            await expect(page.locator("//a[@href='/logout']")).toBeHidden();
        })
    });

    describe("CRUD", () => {
        beforeEach(async()=>{
            //perform Login
            await page.goto(host);
            await page.click("//a[text()='Login']");       
            await page.waitForSelector("//form");
            await page.fill("//input[@id='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[@type='submit']");           

        })

        test("Create a postcard", async()=>{
            //Arrange

            let random = Math.floor(Math.random()*1000);
            petName = `name_${random}`;

            await page.click("//a[text()='Create Postcard']"); 
            await page.waitForSelector("//form");
            await page.fill("//input[@name='name']", petName);
            await page.fill("//input[@name='breed']", "RandomBreed");
            await page.fill("//input[@name='age']", "3 years");
            await page.fill("//input[@name='weight']", "5kg");
            await page.fill("//input[@name='image']", './images/imagesguinea-pig.jpg');

            await page.click("//button[@type='submit']"); 

            //Assert
            await expect(page.locator(`//div[@class='animals-board']//h2[text()='${petName}']`)).toBeVisible();
            expect(page.url()).toBe(host + "/catalog");
        })

        test("Edit postcard", async()=>{
            //Arrange
            await page.goto(host + '/catalog');
            await page.click(`//div[@class='animals-board']//h2[text()='${petName}']//following-sibling::div//a`);

            await page.click("//a[text()='Edit']");
            await page.waitForSelector("//form");

            petName += "_Edited";

            //Act
            await page.fill("//input[@name='name']", petName);
            await page.click("//button[@type='submit']");

            //Assert
            await expect(page.locator('div.animalInfo h1',  {hasText:petName})).toHaveCount(1);           

        })

        test("Delete a postcard", async()=>{
            //Arrange
            await page.click("//a[text()='Dashboard']");
            await page.click(`//div[@class='animals-board']//h2[text()='${petName}']//following-sibling::div//a`);

            //Act
            await page.click("//a[@class='remove']");

            //Assert
            await expect(page.locator(`//div[@class='animals-board']//h2`,  {hasText:petName})).toHaveCount(0); 
            await expect(page.url()).toBe(host + "/catalog") 

        })


    });
})