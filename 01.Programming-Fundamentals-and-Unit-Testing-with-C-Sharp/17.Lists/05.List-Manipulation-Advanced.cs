using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

        string line = "";
        while ((line = Console.ReadLine()) != "end")
        {
            string[] token = line
                .Split(" ")
                .ToArray();

            string command = token[0];

            if (command == "Contains")
            {
                PrintContainsNumberResult(numbers, token);
            }
            else if (command == "PrintEven")
            {
                PrintEven(numbers);
            }
            else if (command == "PrintOdd")
            {
                PrintOdd(numbers);
            }
            else if (command == "GetSum")
            {
                PrintTheSumOfTheNumbers(numbers);
            }
            else if (command == "Filter")
            {
                PrintFilter(numbers, token);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    private static void PrintFilter(List<int> numbers, string[] token)
    {
        string condition = token[1];
        int number = int.Parse(token[2]);

        if (condition == "<")
        { 
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= number)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }           
        }
        else if (condition == "<=")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > number)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }
        }
        else if (condition == ">")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= number)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }
        }
        else if (condition == ">=")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < number)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }
        }
    }

    private static void PrintTheSumOfTheNumbers(List<int> numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine(sum);
    }

    private static void PrintContainsNumberResult(List<int> numbers, string[] token)
    {
        int item = int.Parse(token[1]);
        string result = numbers.Contains(item) ? "Yes" : "No such number";
        Console.WriteLine(result);
    }

    private static void PrintOdd(List<int> numbers)
    {
        List<int> oddNumbers = new List<int>();
        foreach (int item in numbers)
        {
            if (item % 2 == 1)
            {
                oddNumbers.Add(item);
            }
        }
        Console.WriteLine(string.Join(" ", oddNumbers));
    }

    private static void PrintEven(List<int> numbers)
    {
        List<int> evenNumbers = new List<int>();
        foreach (int item in numbers)
        {
            if (item % 2 == 0)
            {
                evenNumbers.Add(item);
            }
        }
        Console.WriteLine(string.Join(" ", evenNumbers));
    }
}
