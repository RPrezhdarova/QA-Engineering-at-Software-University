using System.Data;
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
            if (command == "Add")
            {
                int item = int.Parse(token[1]);
                numbers.Add(item);
            }
            else if (command == "Remove")
            {
                int item = int.Parse(token[1]);
                numbers.Remove(item);
            }
            else if (command == "RemoveAt")
            {
                int index = int.Parse(token[1]);
                numbers.RemoveAt(index);
            }
            else if (command == "Insert")
            {
                int item = int.Parse(token[1]);
                int index = int.Parse(token[2]);
                numbers.Insert(index, item);
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}
