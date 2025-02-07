const { test, expect } = require("@playwright/test");

//verify user can add task
test("User can add task", async ({page}) => {
    //Arrange
    await page.goto('http://localhost:8080');

    //Act
    await page.fill('#task-input', 'Test Task 1');
    await page.click('#add-task');

    //Assert
    const taskText = await page.textContent('.task');
    expect(taskText).toContain('Test Task 1')
})

//verify user can delete tasks

test("user can delete tasks", async({page}) => {
    //Arrange -> add task
    await page.goto('http://localhost:8080');   
    await page.fill('#task-input', 'Test Task 1');
    await page.click('#add-task');

    //Act -> delete task
    await page.click('.task .delete-task');

    //Assert
    const tasks = await page.$$eval('.task', tasks => tasks.map(
        task => task.textContent
    ));
    expect(tasks).not.toContain('Test Task 1')
})

//verify user can add task as complete
test("User can mark task as complete", async ({page}) => {
    //Arrange
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Test Task 1');
    await page.click('#add-task');

    //Act -> complete task
     await page.click('.task .task-complete');

    //Assert
    const completedTask = await page.$('.task.completed')
    expect(completedTask).not.toBeNull();
})

//verify user can filter tasks
test("User can filter tasks", async ({page}) => {
    //Arrange
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Test Task 1');
    await page.click('#add-task');
    await page.click('.task .task-complete');

    //Act -> filter task
    await page.selectOption('#filter', "Completed")

    //Assert
    const incompleteTasks = await page.$('.task:not(.completed)');
    expect(incompleteTasks).toBeNull;
})



