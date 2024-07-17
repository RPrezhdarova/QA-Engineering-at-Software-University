class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        double avarageValue = (input[((input.Length - 1) / 2)] + input[input.Length / 2]) / 2.0;
        Console.WriteLine($"{avarageValue:F2}");
    }
}
