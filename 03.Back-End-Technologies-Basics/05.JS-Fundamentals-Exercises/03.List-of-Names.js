function listOfNames(array){
    array.sort((a, b) => a.localeCompare(b));
    array.forEach((element, index) =>{
        console.log(`${index+1}.${element}`);
    });
}
