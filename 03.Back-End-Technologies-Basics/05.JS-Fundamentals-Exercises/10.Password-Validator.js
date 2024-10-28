function passwordValidator(password){
    let isValid = true;
  
    //rule: 1
    if(password.length < 6 || password.length > 10){
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }
    //rule:2
    if(!/^[A-Za-z0-9]+$/.test(password)){
        console.log("Password must consist only of letters and digits");
        isValid = false;
    }
    //rule: 3
    let digitsCount = 0;
    for(let char of password){        
        if(char>= '0' && char<= '9'){
            digitsCount++;
        }
    }
    if (digitsCount<2){
        console.log("Password must have at least 2 digits");
        isValid = false;
    }
    if (isValid){
        console.log("Password is valid");
    }    
}
