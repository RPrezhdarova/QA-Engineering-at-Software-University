class Program
{
    static void Main()
    {
        int[] inputArray = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        int number = int.Parse(Console.ReadLine());
        double sum = 0;

        for (int i = inputArray.Length - number; i < inputArray.Length; i++)
        {
            sum += (double)inputArray[i];
        }
        double averageValue = sum / number;
        Console.WriteLine($"{averageValue:F2}");
    }
}
