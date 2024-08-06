int n = int.Parse(Console.ReadLine());
double devTwo = 0;
double devThree = 0;
double devFour = 0;

for (int i = 0; i < n; i++)
{
    int a = int.Parse(Console.ReadLine());
    if (a % 2 == 0)
    {
        devTwo += 100;
    }
    if (a % 3 == 0)
    {
        devThree += 100;
    }
    if (a % 4 == 0)
    {
        devFour += 100;
    }
}
Console.WriteLine($"{devTwo/3:F2}%");
Console.WriteLine($"{devThree/3:F2}%");
Console.WriteLine($"{devFour/3:F2}%");
