function printVacationPrice(input){
let groupNumber=parseInt(input[0]);
let groupType=input[1];
let weekDay=input[input.length-1];
let price;
let totalPrice;

if(groupType==='Students'){
    price=(weekDay==='Friday') ? 8.45:
    (weekDay==='Saturday') ? 9.80:
    (weekDay==='Sunday') ? 10.46 :0;
    }
else if(groupType==='Business'){
    price= (weekDay==='Friday') ? 10.90:
    (weekDay==='Saturday')? 15.60:
    (weekDay==='Sunday')? 16 :0;
    }
else if(groupType==='Regular'){
    price= (weekDay==='Friday') ? 15:
    (weekDay==='Saturday') ? 20:
    (weekDay==='Sunday') ? 22.50 :0;    
}
totalPrice=price * groupNumber;
if(groupType==='Students' && groupNumber>=30){
    totalPrice*=0.85;
}
else if(groupType==='Business' && groupNumber>=100){
    totalPrice-=10*price;
}
else if(groupType==='Regular' && (groupNumber>=10&&groupNumber<20)){
    totalPrice*=0.95;
}
console.log(`Total price: ${totalPrice.toFixed(2)}`);
}
