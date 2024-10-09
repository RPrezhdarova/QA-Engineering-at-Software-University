function fruit(input){
    let typeOfFruit=input[0];
    let weightInGrams=input[1];
    pricePerKg=input[2];
    let weightInKg=weightInGrams / 1000.0;
    let neededMoney= pricePerKg * weightInKg;
    console.log(`I need $${neededMoney.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${typeOfFruit}.`);
}
