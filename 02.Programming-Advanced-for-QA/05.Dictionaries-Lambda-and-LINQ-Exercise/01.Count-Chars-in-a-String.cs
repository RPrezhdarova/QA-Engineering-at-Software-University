class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<char, int> characters = new Dictionary<char, int>();

        foreach(char ch in input)
        {
            if (ch !=' ')
            {
                if (characters.ContainsKey(ch))
                {
                    characters[ch]++;
                }
                else
                {
                    characters.Add(ch, 1);
                }
            }
        }
        foreach (KeyValuePair<char, int> entry in characters)
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }
    }
}
