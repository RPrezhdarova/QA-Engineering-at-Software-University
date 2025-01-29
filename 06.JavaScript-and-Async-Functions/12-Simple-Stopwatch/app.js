let stopWatchInterval;
let elapsedTime=0;

function startStopWatch(){
    console.log("Stopwatch Started");

    stopWatchInterval = setInterval(()=>{
        elapsedTime++;
        console.log(`Elapsed time ${elapsedTime} seconds`);

    }, 1000);
    saveTimeInterval = setInterval(async ()=>{
        	await saveElapsedTime(elapsedTime);
    }, 5000);
}
function stopStopWatch(){
    clearInterval(stopWatchInterval);
    clearInterval(saveTimeInterval);
    saveTimeInterval=null;
    stopWatchInterval = null;
    elapsedTime = 0;
    console.log("Stopwatch stopped");
}

function saveElapsedTime(time){
    return new Promise((resolve, reject)=>{
        setTimeout(()=>{
            console.log(`Elapsed time saved: ${time}`);
            resolve();
        }, 500);
    });
}