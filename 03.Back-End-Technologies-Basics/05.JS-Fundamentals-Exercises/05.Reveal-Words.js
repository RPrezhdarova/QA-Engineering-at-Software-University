function revealWords( words, sentence){
    let wordList=words.split(', ');
    wordList.forEach(word=> {
        let template = "*".repeat(word.length);
        sentence=sentence.replace(template, word)
    });
    return sentence;
}
