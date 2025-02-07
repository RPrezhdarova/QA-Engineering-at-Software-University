function subtract() {
    let number1 = Number(document.getElementById("firstNumber").value);
    let number2 = Number(document.getElementById("secondNumber").value);

    let sum = number1 - number2;
    let resultDiv = document.getElementById("result");
    resultDiv.textContent = sum;
    
} 