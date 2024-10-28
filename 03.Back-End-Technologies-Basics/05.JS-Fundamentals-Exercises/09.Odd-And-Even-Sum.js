function oddAndEvenSum(number){
    let oddSum=0;
    let evenSum=0;

    let numberInString=number.toString();
    for(let digit of numberInString){
        let currentDigitAsNumber=Number(digit);
        if(currentDigitAsNumber%2===0){
            evenSum+=currentDigitAsNumber;
        }
        else{
            oddSum+=currentDigitAsNumber;
        }
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
