function encodeAndDecodeMessages() {
    let encodeAndSendButton = document.getElementsByTagName('button')[0];
    let decodeAndReadButton = document.getElementsByTagName('button')[1];
    let textAreaEncode = document.getElementsByTagName('textarea')[0];
    let textAreaDecode = document.getElementsByTagName('textarea')[1];

    encodeAndSendButton.addEventListener('click', sendAndEncode);
    decodeAndReadButton.addEventListener('click', decode);

    function nextChar(c){
        return String.fromCharCode(c.charCodeAt(0) + 1)
    }
    function previousChar(c){
        return String.fromCharCode(c.charCodeAt(0) - 1)
    }

    function transform(text, fn){
        return text.split('').map(fn).join('');
    }

    function sendAndEncode(){
        let valueToEncode = textAreaEncode.value;
        let encodedValue = transform(valueToEncode, nextChar);
        textAreaDecode.value = encodedValue;
    }
    function decode(){
        textAreaDecode.value = transform(textAreaDecode.value, previousChar);        
    }

}