class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int currentDigit = number;

        while (number > 0)
        {
            currentDigit = number % 10;
            switch (currentDigit)
            {
                case 1: Console.WriteLine("one"); break;
                case 2: Console.WriteLine("two"); break;
                case 3: Console.WriteLine("three"); break;
                case 4: Console.WriteLine("four"); break;
                case 5: Console.WriteLine("five"); break;
                case 6: Console.WriteLine("six"); break;
                case 7: Console.WriteLine("seven"); break;
                case 8: Console.WriteLine("eight"); break;
                case 9: Console.WriteLine("nine"); break;
            }
            number /= 10;
        }
    }
}
