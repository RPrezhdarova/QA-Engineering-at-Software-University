using System.ComponentModel.Design;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToList();

        string command = "";
        while((command=Console.ReadLine()) !="end")
        {
            string[] tokens = command.Split(" ");
            string operation = tokens[0];            

            if (operation == "Delete")
            {
                DeleteOperation(numbers, tokens);
            }
            else if (operation == "Insert")
            {
                InsertOperation(numbers, tokens);
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
    private static void InsertOperation(List<int> numbers, string[] tokens)
    {
        int index = int.Parse(tokens[2]);
        int elementForInsertion = int.Parse(tokens[1]);
        numbers.Insert(index, elementForInsertion);
    }
    private static void DeleteOperation(List<int> numbers, string[] tokens)
    {
        int elementForRemoval = int.Parse(tokens[1]);
        while (numbers.Contains(elementForRemoval))
        {
            numbers.Remove(elementForRemoval);
        }
    }
}
