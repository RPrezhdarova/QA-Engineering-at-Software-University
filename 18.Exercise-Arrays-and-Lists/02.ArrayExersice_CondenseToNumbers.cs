using System.Xml.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        List<int> adjacentElements = new List<int>();

        if (numbers.Length == 1)
        {
            Console.WriteLine(numbers[0]);
        }
        else if (numbers.Length > 1)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int sum = numbers[i];
                sum += numbers[i + 1];
                adjacentElements.Add(sum);
            }
            while (adjacentElements.Count != 1)
            {
                List<int> temporaryLists = new List<int>();

                for (int i = 0; i < adjacentElements.Count - 1; i++)
                {
                    int sum = adjacentElements[i];
                    sum += adjacentElements[i + 1];
                    temporaryLists.Add(sum);
                }
                adjacentElements = temporaryLists;
            }
            Console.WriteLine(string.Join(" ", adjacentElements));
        }
    }
}

