class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        int startIndex= int.Parse(Console.ReadLine());
        int endIndex= int.Parse(Console.ReadLine());

        int sum = 0;
        double averagePrice = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            sum+= input[i];
        }

        averagePrice = sum / (endIndex - startIndex +1.00);
        Console.WriteLine($"{averagePrice:F2}");
    }
}
