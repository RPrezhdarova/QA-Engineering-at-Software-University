double firstNumber = double.Parse(Console.ReadLine());
double secondNumber = double.Parse(Console.ReadLine());

double additionResult = firstNumber + secondNumber;
double subtractionResult = firstNumber - secondNumber;
double multiplicationResult = firstNumber * secondNumber;
double divisionResult = firstNumber / secondNumber;

Console.WriteLine($"{firstNumber:F2} + {secondNumber:F2} = {additionResult:F2}");
Console.WriteLine($"{firstNumber:F2} - {secondNumber:F2} = {subtractionResult:F2}");
Console.WriteLine($"{firstNumber:F2} * {secondNumber:F2} = {multiplicationResult:F2}");
Console.WriteLine($"{firstNumber:F2} / {secondNumber:F2} = {divisionResult:F2}");
