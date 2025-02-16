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

let albumName = "";

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
            await page.click("//a[@href='/register']");

            await page.waitForSelector("//form");

            //Act
            let random = Math.floor(Math.random()*1000);
            user.email =`email_${random}@abv.bg`;

            await page.locator("//input[@id='email']").fill(user.email);
            await page.locator("//input[@name='password']").fill(user.password);
            await page.locator("//input[@class='conf-pass']").fill(user.confirmPass);

            await page.click("//button[text()='Register']");

            //Assert
            await expect(page.locator("//a[@href='/logout']")).toBeVisible();
            expect(page.url()).toBe(host + '/');
            
        })

        test("Login with valid data", async()=>{
            //Arrange
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");

            //Act
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[text()='Login']")

            //Assert
            await expect(page.locator("//a[@href='/logout']")).toBeVisible();
            expect(page.url()).toBe(host + '/');
        })
        test("Logout from the application", async()=>{
            //Arrange -> login
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[text()='Login']")

            //Act->Logout
            await page.click("//a[@href='/logout']");

            //Assert
            await expect(page.locator("//a[@href='/login']")).toBeVisible();
            expect(page.url()).toBe(host + '/');
        })
    });

    describe("navbar", () => {
        test("Navigation for Logged-in users", async()=>{
            //Arrange-> Login
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");

            //Act
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[text()='Login']");

            //Assert
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[text()='Catalog']")).toBeVisible();
            await expect(page.locator("//a[text()='Search']")).toBeVisible();
            await expect(page.locator("//a[text()='Create Album']")).toBeVisible();
            await expect(page.locator("//a[@href='/logout']")).toBeVisible();

            await expect(page.locator("//a[@href='/login']")).toBeHidden();
            await expect(page.locator("//a[@href='/register']")).toBeHidden();
        })
        test("Navigation for guest users", async()=>{
            await page.goto(host);

             //Assert
             await expect(page.locator("//a[text()='Home']")).toBeVisible();
             await expect(page.locator("//a[text()='Catalog']")).toBeVisible();
             await expect(page.locator("//a[text()='Search']")).toBeVisible();
             await expect(page.locator("//a[text()='Create Album']")).toBeHidden();
             await expect(page.locator("//a[@href='/logout']")).toBeHidden();
 
             await expect(page.locator("//a[@href='/login']")).toBeVisible();
             await expect(page.locator("//a[@href='/register']")).toBeVisible();
        })
    });

    describe("CRUD", () => {
        beforeEach(async()=>{
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@name='password']", user.password);
            await page.click("//button[text()='Login']");
        })

        test("Create an album", async()=>{
            //Arrange
            await page.click("//a[text()='Create Album']");
            await page.waitForSelector("//form");

            //Act
            let random = Math.floor(Math.random()*1000);
            albumName=`album_name${random}`;

            await page.locator("//input[@name='name']").fill(albumName);
            await page.locator("//input[@name='imgUrl']").fill("/images/pinkFloyd.jpg");
            await page.locator("//input[@name='price']").fill("15");
            await page.locator("//input[@name='releaseDate']").fill("29.01.2000");
            await page.locator("//input[@name='artist']").fill("Some Artist");
            await page.locator("//input[@name='genre']").fill("POP");
            await page.locator("//textarea[@name='description']").fill("some description");

            await page.click("//button[text()='Add New Album']");

            //Assert
            await expect(page.locator("//div[@class='card-box']//p[@class='name']", {hasText:albumName})).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        })
        test("Edit an album", async()=>{
            await page.click("//a[text()='Search']");
            await page.locator("//input[@id='search-input']").fill(albumName);
            await page.click("//button[text()='Search']");

            //Act
            await page.click("//a[@id='details']");
            await page.click("//a[@class='edit']");
            await page.waitForSelector("//form");
            await page.locator("//input[@id='name']").fill(albumName);
            await page.click("//button[@type='submit']");

            //Assert
            await expect(page.locator("//h1", {hasText: albumName})).toHaveCount(1);
        })

        test("Delete an album", async()=>{
            await page.click("//a[text()='Search']");
            await page.locator("//input[@id='search-input']").fill(albumName);
            await page.click("//button[text()='Search']"); 
             
              //Act        
            await page.click("//a[@id='details']");
            await page.click("//a[@class='remove']");            

            //Assert
            await expect(page.locator("//div[@class='card-box']//p[@class='name']", {hasText:albumName})).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        })
    });
});