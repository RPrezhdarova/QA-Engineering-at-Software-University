double numberOne = double.Parse(Console.ReadLine());
double numberTwo = double.Parse(Console.ReadLine());
char @operator = char.Parse(Console.ReadLine());
double result = 0;
switch (@operator)
{
    case '+': result = numberOne + numberTwo; break;
    case '-': result = numberOne - numberTwo; break;
    case '*': result = numberOne * numberTwo; break;
    case '/': result = numberOne / numberTwo; break;
}
Console.WriteLine($"{numberOne} {@operator} {numberTwo} = {result:F2}");
