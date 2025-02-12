const  { test, describe, beforeAll, beforeEach, afterAll, afterEach, expect } = require('@playwright/test');
const {chromium} = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPassword: "123456"
}

let game = {
    title: "",
    category: "",
    maxLevel: 99,
    image: "https://media.istockphoto.com/id/1830404011/vector/game-concept-vector-colorful-illustration-game-text-and-illustrations-of-game-related.jpg?s=2048x2048&w=is&k=20&c=KG5dmVa4PH1ud_zudxRbjP22bKhRx7edjHT0bSYqOvk=",
    id: "",
    summary: ""

}

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });
    afterAll(async () =>{
        await browser.close();
    });

    beforeEach(async () =>{
        context = await browser.newContext();
        page = await browser.newPage();
    });
    afterEach(async () =>{
        await page.close();
        await context.close();
    });

    describe("Authentication Tests", () =>{
        test("Register with valid data", async () =>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text() = 'Register']");
            await page.waitForSelector("form");
            
            let random = Math.floor(Math.random() * 1000);
            user.email = `abv_${random}@abv.bg`;

            //Act
            await page.fill("//input[@id='email']", user.email);
            await page.fill("//input[@id='register-password']", user.password);
            await page.fill("//input[@id='confirm-password']", user.confirmPassword);
           
            await page.click("//input[@type='submit']");
            
            //Assert
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();
            expect(page.url()).toBe(host + '/');            
        });

        test("Register with empty fields", async () =>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text() = 'Register']");
            await page.waitForSelector("form");            
            
            //Act      
            //create dialog Listener and assert         
            page.on('dialog', async dialog =>{
                expect(dialog.message()).toBe("No empty fields are allowed and confirm password has to match password!")

                await dialog.accept();
            })        
            //click register button
            await page.click("//input[@type='submit']");
            
            //Assert
            expect(page.url()).toBe(host + '/register');            
        });
        test("Login with valid credentials", async () =>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text() = 'Login']");
            await page.waitForSelector("form");         

            //Act
            await page.fill("//input[@type='email']", user.email);
            await page.fill("//input[@type='password']", user.password);        
            await page.click("//input[@type='submit']");
            
            //Assert
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();
            expect(page.url()).toBe(host + '/');   
        });
        test("Login with empty filds", async () =>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text() = 'Login']");
            await page.waitForSelector("form");         

            //Act      
            const dialogPromise = page.waitForEvent('dialog');           
            await page.click("//input[@type='submit']");
            const dialog = await dialogPromise;
            
            //Assert
            expect(dialog.message()).toBe("Unable to log in!");
            await dialog.accept();

            expect(page.url()).toBe(host + "/login");
        });
        test("Logout from the application", async () =>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text() = 'Login']");
            await page.waitForSelector("form");      
            await page.fill("//input[@type='email']", user.email);
            await page.fill("//input[@type='password']", user.password);        
            await page.click("//input[@type='submit']");

            //Act
            await page.click("//a[text()='Logout']");

            //Assert
            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            expect(page.url()).toBe(host + '/')
        });
    });
    describe("Navbar Tests", () =>{
        test("Logged in users should see correct buttons", async () =>{
            //Arrange
            await page.goto(host);
            await page.click("//a[text() = 'Login']");
            await page.waitForSelector("form"); 

            //Act
            await page.fill("//input[@type='email']", user.email);
            await page.fill("//input[@type='password']", user.password);        
            await page.click("//input[@type='submit']");

            //Assert
            await expect(page.locator("//a[text()='All games']")).toBeVisible();
            await expect(page.locator("//a[text()='Create Game']")).toBeVisible();
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();

            await expect(page.locator("//a[text()='Login']")).toBeHidden();
            await expect(page.locator("//a[text()='Register']")).toBeHidden();
        })
        test("Guest users should see the correct buttons", async() =>{
            //Act
            await page.goto(host);

            //Assert
            await expect(page.locator("//a[text()='All games']")).toBeVisible();
            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            await expect(page.locator("//a[text()='Register']")).toBeVisible();

            await expect(page.locator("//a[text()='Create Game']")).toBeHidden();
            await expect(page.locator("//a[text()='Logout']")).toBeHidden();
        })
    });
    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);

            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator("#email").fill(user.email);
            await page.locator("#login-password").fill(user.password);
            await page.click('[type="submit"]')
        });

        test('create does NOT work with empty fields', async () => {
            await page.click('text=Create Game');
            await page.waitForSelector('form');
            await page.click('[type="submit"]');

            expect(page.url()).toBe(host + '/create');
        });

        test('create with valid data successfully creates the game', async () => {
            let random = Math.floor(Math.random() * 1000);
            game.title = `Game title ${random}`;
            game.category = `Game category ${random}`;

            await page.click('text=Create Game');
            await page.waitForSelector('form');

            await page.fill('[name="title"]', game.title);
            await page.fill('[name="category"]', game.category);
            await page.fill('[name="maxLevel"]', game.maxLevel);
            await page.fill('[name="imageUrl"]', game.image);
            await page.fill('[name="summary"]', game.summary);

            await page.click('[type="submit"]');
            
            await expect(page.locator('.game h3', { hasText: game.title })).toHaveCount(1);
            expect(page.url()).toBe(host + '/');
        });

        test('details show edit/delete buttons for owner', async () => {
            await page.goto(host + "/catalog");

            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);

            game.id = page.url().split('/').pop();

            await expect(page.locator("//a[text()='Delete'")).toBeVisible();
            await expect(page.locator("//a[text()='Edit'")).toBeVisible();
        });

        test('non-owner does NOT see delete and edit buttons', async () => {
            await page.goto(host + "/catalog");
            await page.click(`.allGames .allGames-info:has-text("MineCraft") >> .details-button`);

            await expect(page.locator('text="Delete"')).toBeHidden();
            await expect(page.locator('text="Edit"')).toBeHidden();
        });

        test('edit with valid data successfully modifies the game', async () => {
            await page.goto(host + "/catalog");

            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);
            await page.click("//a[text()='Edit'");

            await page.waitForSelector('form');

            game.title = `${game.title}_edit`;

            await page.locator('[name="title"]').fill(game.title);

            await page.click('[type="submit"]');
            
            await expect(page.locator('.game-header h1', { hasText: game.title })).toHaveCount(1);
            expect(page.url()).toBe(host + `/details/${game.id}`);
        });

        test('delete successfully deletes the game', async () => {
            await page.goto(host + "/catalog");

            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);

            await page.click("//a[text()='Delete'");
            
            await expect(page.locator('.game h3', { hasText: game.title })).toHaveCount(0);
            expect(page.url()).toBe(host + '/');
        });
    })

    describe('Home Page', () => {
        test('show home page', async () => {
            await page.goto(host);

            expect(page.locator('.welcome-message h2')).toHaveText("ALL new games are");
            expect(page.locator('.welcome-message h3')).toHaveText("Only in GamesPlay");
            expect(page.locator('#home-page h1')).toHaveText("Latest Games");
            
            const gameDivs = await page.locator('#home-page .game').all();
            
            expect(gameDivs.length).toBeGreaterThanOrEqual(3);
        });
    });
    
})