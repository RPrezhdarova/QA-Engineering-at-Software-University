class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine()
                   .Split(" ")
                   .Where(text => text.Length % 2 == 0)
                   .ToArray();

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
