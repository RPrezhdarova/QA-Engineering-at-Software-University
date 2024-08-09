int n=int.Parse(Console.ReadLine());
int currentNumber = 1;
for (int row = 0; currentNumber <= n; row++)
{
    for (int col = 1; col <= row && currentNumber<=n; col++)
    {        
        Console.Write($"{currentNumber} ");       
        currentNumber++;       
    }
    Console.WriteLine();
}
