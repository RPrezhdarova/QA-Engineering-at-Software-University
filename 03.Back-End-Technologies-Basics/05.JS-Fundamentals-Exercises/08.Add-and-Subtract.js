function addAndSubstract(num1, num2, num3){
    function sum(num1, num2){
        let resultSum=  num1 + num2;
        return resultSum;
    }
    function substract(resultSum, num3){
        return resultSum-num3;
    }
    let resultSum=sum(num1, num2);
    let resultFinal=substract(resultSum, num3);
    console.log(resultFinal);
}
