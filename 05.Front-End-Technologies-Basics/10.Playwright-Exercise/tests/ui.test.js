const { test, expect } = require('playwright/test')

test("Verify 'All Books' link is visible", async ({page}) => {
    //Test steps
    await page.goto("http://localhost:3000");

    await page.waitForSelector('nav.navbar');

    const allBooks = await page.locator('a[href="/catalog"]');
    const isLinkVisible = await allBooks.isVisible();

    expect(isLinkVisible).toBe(true);
})

test("Verify 'Login' button is visible", async({page}) => {

    await page.goto("http://localhost:3000/");

    await page.waitForSelector('nav.navbar');

    const loginButton = await page.locator("//a[text() = 'Login']");
    const isLoginButtonVisible = await loginButton.isVisible();

    expect(isLoginButtonVisible).toBe(true);
})

test("Verify 'Register' button is visible", async ({page}) => {
    //Test steps
    await page.goto("http://localhost:3000");

    await page.waitForSelector('nav.navbar');

    const registerButton = await page.locator("//a[text() = 'Register']");
    const isRegisterButtonVisible = await registerButton.isVisible();

    expect(isRegisterButtonVisible).toBe(true);
})

test('Verify "All Books" link is visible when user is logged in', async ({page}) => {
    //Arrange
    await page.goto('http://localhost:3000/login');

    //Act
    await page.fill("//input[@name='email']", "peter@abv.bg");
    await page.fill("//input[@name='password']", "123456");
    await page.click("//input[@type='submit']");

    const allBooksLink = await page.locator("//a[@href='/catalog']");
    const isAllBooksLinkVisible = await allBooksLink.isVisible();

    //Assert
    expect(isAllBooksLinkVisible).toBe(true);
})

test('Verify buttons are visible when user is logged in', async ({page}) => {
    //Arrange
    await page.goto('http://localhost:3000/login');

    //Act
    await page.fill("//input[@name='email']", "peter@abv.bg");
    await page.fill("//input[@name='password']", "123456");
    await page.click("//input[@type='submit']");

    const emailElement = await page.locator("//div[@id='user']//span");
    const myBooksButton = await page.locator("a[text()='My Books']");
    const addBooksButton = await page.locator("a[text()='My Books']");
    const logoutButton = await page.locator("a[text()='Logout']");

    const isEmailButtonVisible = await emailElement.isVisible();
    const isMyBooksButton = await emailElement.isVisible();
    const isAddBooksButton = await emailElement.isVisible();
    const isLogoutButton = await emailElement.isVisible();

    //Assert
    expect(isEmailButtonVisible).toBe(true);
    expect(isMyBooksButton).toBe(true);
    expect(isAddBooksButton).toBe(true);
    expect(isLogoutButton).toBe(true);    
})

test('Login with valid credentials', async ({page}) => {
    //Arrange
    await page.goto('http://localhost:3000/login');

    //Act
    await page.fill("//input[@name='email']", "peter@abv.bg");
    await page.fill("//input[@name='password']", "123456");
    await page.click("//input[@type='submit']");

    //Assert
    await expect(page.locator("//a[text() = 'Add Book']")).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/catalog');
})

test('Login with empty fields', async ({page}) => {
    //Arrange
    await page.goto('http://localhost:3000/login');

    //Act  
    await page.click("//input[@type='submit']");

    page.on('dialog', async ({dialog}) =>{
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");

        await dialog.accept();
    });
    //Assert
    await expect(page.locator("//a[text() = 'Login']")).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/login');
})

test('Submit book with all field', async ({page}) => {
    //Arrange
    await page.goto('http://localhost:3000/login'); 
    await page.fill("//input[@id='email']", "peter@abv.bg");
    await page.fill("//input[@id='password']", "123456");

    await Promise.all([
        page.click("//input[@type='submit']"),
        page.waitForURL("http://localhost:3000/catalog")
    ]);

    await page.click("//a[@href='/create']");

    await page.waitForSelector("#create-form");

    await page.fill("#title", "Some new title");
    await page.fill("#description", "Some new description");
    await page.fill("#image", "some path");
    await page.selectOption("#type", "Classic");
    await page.click("//input[@type= 'submit']");
    
    //Assert
    await page.waitForURL("http://localhost:3000/catalog");
    expect(page.url()).toBe("http://localhost:3000/catalog");

})


