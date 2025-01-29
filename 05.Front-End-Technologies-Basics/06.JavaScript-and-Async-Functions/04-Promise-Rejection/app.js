function promiseRejection() {
    new Promise((resolve, reject) => {
        setTimeout(()=> {
           let sucess = false;
           if (sucess){
            resolve("Success!");
           }
           else {
            reject(new Error("Something went wrong!"));
           }
            
        }, 1000)
    })
    .then((result) => {console.log(result)})
    .catch((error)=> {console.log(error)})
}

promiseRejection();