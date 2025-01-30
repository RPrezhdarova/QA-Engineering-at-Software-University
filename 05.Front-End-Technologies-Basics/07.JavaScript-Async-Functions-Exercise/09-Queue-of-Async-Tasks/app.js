class AsyncQueue {
    constructor() {
        this.tasks = [];
        this.processing = false;
    }

    addTask(taskFunc) {
        this.tasks.push(taskFunc);
        if (!this.processing) this.processTasks();
    }

    async processTasks() {
        this.processing = true;
        while (this.tasks.length > 0) {
            const currentTaskFunc = this.tasks.shift();
            await currentTaskFunc();
        }
        this.processing = false;
    }
}

function startQueue() {
    const tasks = new AsyncQueue();
    tasks.addTask(() => new Promise(resolve => setTimeout(() => { console.log("Task 1 done"); resolve(); }, 1000)));
    tasks.addTask(() => new Promise(resolve => setTimeout(() => { console.log("Task 2 done"); resolve(); }, 1500)));
    tasks.addTask(() => new Promise(resolve => setTimeout(() => { console.log("Task 3 done"); resolve(); }, 500)));
}

