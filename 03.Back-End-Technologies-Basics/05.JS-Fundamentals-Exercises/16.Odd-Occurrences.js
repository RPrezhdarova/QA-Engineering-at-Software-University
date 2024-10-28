function oddOccurences(sentence){
    let splitSentence =sentence.toLowerCase().split(' ');
    let array={};

    for(let i=0; i<splitSentence.length; i++){
        let currentWord=splitSentence[i];


        if(array.hasOwnProperty(currentWord)){
           array[currentWord]++;
        }
        else{
            array[currentWord]=1;
        }
    }
    let oddOccurences=[];
    for(let word in array){
        
        if(array[word] % 2 !== 0){
            oddOccurences.push(word);
        }
    }
    console.log(oddOccurences.join(' '));
}
