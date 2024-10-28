function arrayRotation(array, numberofRotations)
{
let effectiveRotations = numberofRotations % array.length;
let rotatedPart = array.slice(effectiveRotations);
let rotatedTail=array.slice(0, effectiveRotations);
return rotatedPart.concat(rotatedTail).join(' ');
}
