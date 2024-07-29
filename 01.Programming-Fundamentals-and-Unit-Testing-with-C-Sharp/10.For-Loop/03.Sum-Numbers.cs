int n = int.Parse(Console.ReadLine());
double sum = 0;

for (int i=0; i<n; i++)
{
    double currentNumber= double.Parse(Console.ReadLine());
    sum += currentNumber;
}
Console.WriteLine(sum);
