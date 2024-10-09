function sameNumbers(input){

    let stringNumber=""+ input;
    let firstDigit =stringNumber[0];
    let allSame=true;
    let sum=0;
    for (let digit of stringNumber){
        if (digit!== firstDigit)
        {
            allSame=false;
        }
        sum+=parseInt(digit);
    }
    console.log(allSame);
    console.log(sum);
}
