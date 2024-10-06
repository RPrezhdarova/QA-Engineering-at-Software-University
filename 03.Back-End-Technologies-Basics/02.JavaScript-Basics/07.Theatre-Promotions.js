function getPrice(day, age){
    let price;
    if(age<0||age>122){
        console.log('Error!');
        return;
    }
    else {
      if((day==='Weekday'&&(age>=0&&age<=18))||(day==='Weekday'&&(age>64&&age<=122))||(day==='Holiday'&&(age>18&&age<=64))){
      price=12;
      }
      else if(day==='Weekday'&&(age<=64&&age>18)){
      price=18;
      }
      else if((day==='Weekend'&&(age>=0&&age<=18))||(day==='Weekend'&&(age>64&&age<=122))){
      price=15;
      }
      else if(day==='Weekend'&&(age<=64&&age>18)){
      price=20;
      }
      else if((day==='Weekend'&&(age>=0&&age<=18))||(day==='Weekend'&&(age>64&&age<=122))){
      price=15;
      }
      else if(day==='Holiday'&&(age>=0&&age<=18)){
      price=5;
      }
      else if(day==='Holiday'&&(age>64&&age<=122)){
      price=10;    
      }
      console.log(`${price}$`);
    }
}    
