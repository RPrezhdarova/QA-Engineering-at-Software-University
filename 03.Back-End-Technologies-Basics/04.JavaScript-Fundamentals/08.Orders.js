function orders(string, number){
    switch(string){
        case 'coffee': price=1.50;
        break;
        case 'water': price=1.00;
        break;
        case 'coke': price=1.40;
        break;
        case 'snacks': price= 2.00;
        break;
    }
    let result=number*price;
    console.log(`${result.toFixed(2)}`);
}
