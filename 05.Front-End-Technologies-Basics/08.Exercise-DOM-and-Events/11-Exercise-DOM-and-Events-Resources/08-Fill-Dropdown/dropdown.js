function addItem() {
    let inputTextElement = document.getElementById("newItemText");
    let inputValueElement = document.getElementById("newItemValue");
    let selectElement = document.getElementById("menu");

    let option = document.createElement("option");
    option.textContent = inputTextElement.value;
    option.value = inputValueElement.value;

    selectElement.appendChild(option);

    inputTextElement.value= '';
    inputValueElement.value= '';
}