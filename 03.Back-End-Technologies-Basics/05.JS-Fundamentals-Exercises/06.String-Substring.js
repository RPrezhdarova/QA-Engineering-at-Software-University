function stringSubstring(word, text){
    let lowerWord=word.toLowerCase();
    let lowerText=text.toLowerCase();
    
    let wordsArray=lowerText.split(' ');
    if(wordsArray.includes(lowerWord)){
        console.log(word);
    }
    else{
        console.log(`${word} not found!`);
    }
}
