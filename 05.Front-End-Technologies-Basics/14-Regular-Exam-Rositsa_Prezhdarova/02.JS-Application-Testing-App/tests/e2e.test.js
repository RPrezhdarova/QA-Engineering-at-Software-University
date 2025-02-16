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

let bookTitle = "";

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
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.fill("//input[@name='conf-pass']", user.confirmPass);

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
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[@type='submit']");

            //Assert
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();
            expect(page.url()).toBe(host + "/");
        })
        test("Logout from the Application", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text()='Login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[@type='submit']");
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();

            //Act
            await page.click("//a[text()='Logout']");

            //Assert
            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            expect(page.url()).toBe(host + "/");

        })
        
    });

    describe("navbar", () => {
        test("Navigation for Logged-In User Testing", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text()='Login']");

            //Act
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[@type='submit']");

            //Assert
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[@href='/collection']")).toBeVisible();
            await expect(page.locator("//a[@href='/search']")).toBeVisible();
            await expect(page.locator("//a[text()='Create Book']")).toBeVisible();
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();

            await expect(page.locator("//a[text()='Login']")).toBeHidden();
            await expect(page.locator("//a[text()='Register']")).toBeHidden();
        })
        test("Navigation for Guest User Testing", async()=>{
            //Arrange & Act
            await page.goto(host);           

            //Assert
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[@href='/collection']")).toBeVisible();
            await expect(page.locator("//a[@href='/search']")).toBeVisible();
            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            await expect(page.locator("//a[text()='Register']")).toBeVisible();

            await expect(page.locator("//a[text()='Create Book']")).toBeHidden();
            await expect(page.locator("//a[text()='Logout']")).toBeHidden();
        })        
    });

    describe("CRUD", () => {
        beforeEach(async()=>{
            await page.goto(host);
            await page.click("//a[text()='Login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[@type='submit']");
        })
        test("Create a Book Testing", async()=>{
            await page.click("//a[text()='Create Book']");
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random()*1000);
            bookTitle = `title_${random}`;

            await page.fill("//input[@name='title']", bookTitle);
            await page.fill("//input[@name='coverImage']", './images/theGreatGatsby.jpg');
            await page.fill("//input[@name='year']", "1925");
            await page.fill("//input[@name='author']", "F. Scott Fitzgerald");
            await page.fill("//input[@name='genre']", "Tragedy");
            await page.fill("//textarea[@class='description']", "Test description");

            await page.click("//button[@type='submit']"); 

            //Assert
            await expect(page.locator(`//div[@class='book-details']//h2[text()='${bookTitle}']`)).toBeVisible();
            expect(page.url()).toBe(host + "/collection");
        })

        test("Edit a Book Testing", async()=>{
            //Arrange
            await page.click("//a[text()='Search']");
            await page.fill("//input[@name='search']", bookTitle);
            await page.click("//button[text()='Search']");

            await page.click(`//a[text()='${bookTitle}']`);
            await page.click("//a[text()='Edit']");
            await page.waitForSelector("//form");

            bookTitle += "_Edited";

             //Act
             await page.fill("//input[@name='title']", bookTitle);
             await page.click("//button[@type='submit']");

             //Assert
             await expect(page.locator('div.book-info h2',  {hasText:bookTitle})).toHaveCount(1);   
        })

        test("Delete a Book Testing", async()=>{
            //Arrange
            await page.click("//a[text()='Search']");
            await page.fill("//input[@name='search']", bookTitle);
            await page.click("//button[text()='Search']");

            //Act
            await page.click(`//a[text()='${bookTitle}']`);
            await page.click("//a[text()='Delete']");
            
            //Assert           
            await expect(page.locator(`//div[@class='book-details']//h2[text()='${bookTitle}']`,  {hasText:bookTitle})).toHaveCount(0); 
            await expect(page.url()).toBe(host + "/collection");  
        })
    });
});