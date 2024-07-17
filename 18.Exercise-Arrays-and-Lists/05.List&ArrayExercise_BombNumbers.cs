using System.Reflection.Metadata.Ecma335;
class Program
{
    static void Main()
    {
        List<int> input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        int[] token = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        int bombNumber = token[0];
        int power = token[1];

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] == bombNumber)
            {
                int startIndex = i - power;
                int endIndex = i + power;

                if (startIndex < 0)
                    startIndex = 0;

                if (endIndex > input.Count - 1)
                    endIndex = input.Count - 1;

                int countToRemove = endIndex - startIndex + 1;
                input.RemoveRange(startIndex, countToRemove);
                i = startIndex - 1;
            }
        }
        Console.WriteLine(input.Sum());
    }
}
