class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();
        int number = int.Parse(Console.ReadLine());

        int maxNumber = int.MinValue;
        int minNumber = int.MaxValue;

        for (int i = 0; i < number; i++)
        {
            if (input[i]>maxNumber)
                {
                maxNumber = input[i];
            }
            if (input[i]<minNumber)
            {
                minNumber = input[i];
            }
        }
        Console.WriteLine(maxNumber);
        Console.WriteLine(minNumber);
    }
}
