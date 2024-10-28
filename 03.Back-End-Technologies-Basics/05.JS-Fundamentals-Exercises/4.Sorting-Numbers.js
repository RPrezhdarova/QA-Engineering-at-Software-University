function sortingNumbers(array)
{
     let sortedArrayAscending = [...array].sort((a, b) => a - b); 
     let sortedArrayDescending = [...array].sort((a, b) => b - a);
     let result=[];
     let arrayLength=array.length;
     for(let i=0; i<arrayLength/2;i++){
        result.push(sortedArrayAscending[i]);
        if(result.length<array.length){
            result.push(sortedArrayDescending[i]); 
        }                 
     }
    return result;
}
