async function promiseRejectionAsync() {
   try{
      await new Promise((resolve, reject) => {
         setTimeout(()=>{
            reject(new Error("oops!"))
         }, 1000);

         //code to be executed after promise is resolves successfully
      })
   }
   catch(error){
      //code to be executed after promise is rejected
      console.log(error);
   }

}

promiseRejectionAsync()