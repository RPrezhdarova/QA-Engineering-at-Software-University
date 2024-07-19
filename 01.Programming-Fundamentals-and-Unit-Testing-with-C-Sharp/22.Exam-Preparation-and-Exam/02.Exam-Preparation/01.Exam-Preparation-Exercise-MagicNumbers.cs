class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        List<int> magicNumbers= new List<int>();
        for (int i = 1; i <= number; i++)
        {
            int currentNumber = i;
            bool isPrime = true;
            int sum = 0;
            while (currentNumber > 0)
            {
                int currentDigit = currentNumber % 10;
                currentNumber /= 10;
                sum+= currentDigit;
                isPrime = IsPrimeNumber(currentDigit);

                if (!isPrime)
                {
                    break;
                }
            }
            if (isPrime && sum % 2 ==0)
            {
                magicNumbers.Add(i);
            }       
        }
        if (magicNumbers.Count > 0)
        {
            Console.WriteLine(string.Join(" ", magicNumbers));
        }
        else
        {
            Console.Write("no");
        }
    }
    public static bool IsPrimeNumber(int n)
    {
        if (n == 0 || n == 1)
        {
            return false;
        }
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
