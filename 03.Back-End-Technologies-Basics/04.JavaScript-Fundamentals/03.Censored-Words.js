function solve(text, word){     
    let replacement = "*".repeat(word.length);
    let censoredText=text.replace(word, replacement);
    while(censoredText.includes(word)){
        censoredText=censoredText.replace(word, replacement);
    }
    console.log(censoredText);
}
