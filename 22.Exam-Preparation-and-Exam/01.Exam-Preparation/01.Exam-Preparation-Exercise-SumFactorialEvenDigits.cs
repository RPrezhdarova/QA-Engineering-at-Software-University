class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int totalSum = 0;
        while (number >= 1)
        {
            int n = number % 10;
            int sum = 1;
            if (n % 2 == 0)
            {
                for (int i = n; i >= 1; i--)
                {
                    sum *= i;
                }
                totalSum += sum;
            }
            number = number / 10;
        }
        Console.WriteLine(totalSum);
    }
}
