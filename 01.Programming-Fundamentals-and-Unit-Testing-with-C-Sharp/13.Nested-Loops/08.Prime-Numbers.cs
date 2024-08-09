int startNumber = int.Parse(Console.ReadLine());
int endNumber = int.Parse(Console.ReadLine());

for (int number = startNumber; number <= endNumber; number++)
{
    bool isPrime = true;
    for (int i = 2; i<number; i++)
    {
        if (number % i == 0)
        {
            isPrime = false;
        }
    }
    if (isPrime)
    {
        Console.Write($"{number} ");
    }
} 
