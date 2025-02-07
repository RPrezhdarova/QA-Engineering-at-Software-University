function solve() {
  let input = document.getElementById("text").value.toLowerCase();

  let namingConvension = document.getElementById("naming-convention").value;

  let resultSpan = document.getElementById("result");

  let splitted = input.split(' ');
  let resultString = " ";

  if(namingConvension =="Camel Case"){
    resultString += splitted[0];
    for (let i = 1; i < splitted.length; i++){
      resultString += splitted[i][0].toUpperCase() + splitted[i].slice(1, splitted[1].length);
      resultSpan.textContent = resultString;
    }
  }
  else if(namingConvension =="Pascal Case"){
    for (let i = 1; i < splitted.length; i++)
      resultString += splitted[i][0].toUpperCase() + splitted[i].slice(1, splitted[1].length);
      resultSpan.textContent = resultString;
  }
  else{
    resultString.textContent ="Error!";
  }
}