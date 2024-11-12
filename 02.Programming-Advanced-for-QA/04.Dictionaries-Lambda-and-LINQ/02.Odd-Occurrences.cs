class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine()
            .Split(" ")
            .ToArray();

        Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string wordWithLowerCase = word.ToLower();

            if (wordsCount.ContainsKey(wordWithLowerCase))
            {
                wordsCount[wordWithLowerCase]++;
            }
            else
            {
                wordsCount.Add(wordWithLowerCase, 1);
            }
        }

        foreach(KeyValuePair<string, int> entry in wordsCount)
        {
            int counttOccurances = entry.Value;
            if (counttOccurances % 2 !=0 ) 
            {
                Console.Write(entry.Key + " ");
            }
        }
    }
}
