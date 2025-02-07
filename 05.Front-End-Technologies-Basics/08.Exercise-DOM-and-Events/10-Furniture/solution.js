function solve() {
  let tableBody = document.getElementsByTagName("tbody")[0];
  let userInput = document.getElementsByTagName("textarea")[0];
  let resultTextArea = document.getElementsByTagName("textarea")[1];
  let generateButton = document.getElementsByTagName("button")[0];
  let buyButton = document.getElementsByTagName("button")[1];

  generateButton.addEventListener("click", generateRow);
  buyButton.addEventListener("click", buyItems);

  function generateRow(){
    let items = JSON.parse(userInput.value);

    for (const item of items) {
      let tableRow = document.createElement("tr");

      //add td for the image
      let imageTableData = document.createElement("td");
      let image = document.createElement("img");

      image.src = item.img;
      imageTableData.appendChild(image);
      tableRow.appendChild(imageTableData);

      tableBody.appendChild(tableRow);

      //add td for name
      let nameTd = document.createElement("td");
      let nameP = document.createElement("p");

      nameP.textContent = item.name;
      nameTd.appendChild(nameP);
      tableRow.appendChild(nameTd);

      //add td for price
      let priceTd = document.createElement("td");
      let priceP = document.createElement("p");

      priceP.textContent = item.price;
      priceTd.appendChild(priceP);
      tableRow.appendChild(priceTd);

      //add td for decoration factor
      let decorationTd = document.createElement("td");
      let decorationP = document.createElement("p");

      decorationP.textContent = item.decFactor;
      decorationTd.appendChild(decorationP);
      tableRow.appendChild(decorationTd);

      //add td for checkBox
      let checkmarkTd = document.createElement("td");
      let checkmarkInput= document.createElement("input");
      checkmarkInput.type = "checkbox";
      checkmarkTd.appendChild(checkmarkInput);
      tableRow.appendChild(checkmarkTd);


    }
  }
  function buyItems(){
    let furniture = [];
    let tableRows = document.getElementsByTagName("tr");

    for (let i = 1; i< tableRows.length; i++) {
      let checkMark = tableRows[i].children[4].children[0].checked;
      if(checkMark){
        let name = tableRows[i].children[1].children[0].textContent;
        furniture.push(name);
      }
    }
    let result = `Bought furniture: ${furniture.join(", ")}`;
    resultTextArea.value = result;
    
  }  
}