async function chainedPromisesAsync() {
    const p1 = await new Promise((resolve, reject) => {
        setTimeout(()=>{
            resolve("First");
        }, 1000);
    });
    const p2 = await new Promise((resolve, reject) => {
        setTimeout(()=>{
            resolve("Second");
        }, 2000);
    });
    const p3 = await new Promise((resolve, reject) => {
        setTimeout(()=>{
            resolve("Third");
        }, 3000);
    });
    console.log(p1, p2, p3);
}
chainedPromisesAsync() 
