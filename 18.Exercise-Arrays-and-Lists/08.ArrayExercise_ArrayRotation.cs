class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();
        int rotations = int.Parse(Console.ReadLine());
        int[] newArray = new int[input.Length];
        for (int i = 0; i < rotations; i++)
        {
            int rotationNumber = input[0];
            for (int index = 0; index < input.Length - 1; index++)
            {
                input[index] = input[index + 1];
            }
            input[input.Length - 1] = rotationNumber;
        }
        Console.WriteLine(string.Join(" ", input));
    }
}
