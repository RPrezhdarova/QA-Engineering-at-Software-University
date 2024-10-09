function cookingByNumbers(input){
    let number= Number(input[0]);
    const operations = input.slice(1);    //remove the first number of the array
    for (let operation of operations)
    {
    switch(operation){
        case 'chop':
            number /=2;
            console.log(number); 
            break;
        case 'dice':
            number =Math.sqrt(number);
            console.log(number); 
            break;
        case 'spice':
            number +=1;
            console.log(number); 
            break;
        case 'bake':
            number *=3;
            console.log(number); 
            break;
        case 'fillet':
            number -=number*0.2;
            console.log(number); 
            break;
        }       
    }   
}
