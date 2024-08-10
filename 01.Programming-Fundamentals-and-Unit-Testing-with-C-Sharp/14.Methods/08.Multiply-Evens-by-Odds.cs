class Program
{
    static void Main()
    {
        int number = Math.Abs(int.Parse(Console.ReadLine()));
        int result = GetMultipleOfEvenAndOdds(number);
        Console.WriteLine(result);
    }
    static int GetMultipleOfEvenAndOdds(int number)
    {
        return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
    }
    static int GetSumOfEvenDigits(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            int digit = number % 10;
            number /= 10;
            if (digit % 2 == 0)
            {
                sum += digit;
            }            
        }
        return sum;
    }
     static int GetSumOfOddDigits(int number)
     {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                if (digit % 2 == 1)
                {
                    sum += digit;
                }              
            }
        return sum;
    }    
}
