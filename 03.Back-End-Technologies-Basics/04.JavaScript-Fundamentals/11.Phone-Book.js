function solve(arr){
    let phoneBook = {};
    for(let entry of arr){
        let [name, number]= entry.split(' ');
        phoneBook[name]=number;
    }
    for(let name in phoneBook){
        console.log(`${name} -> ${phoneBook[name]}`);
    }
}
