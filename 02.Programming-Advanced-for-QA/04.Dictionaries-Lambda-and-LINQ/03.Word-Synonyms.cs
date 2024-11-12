class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();
        int countWords = int.Parse(Console.ReadLine());

        for (int i = 1; i <= countWords; i++)
        {
            string word = Console.ReadLine();
            string synonym = Console.ReadLine();

            if (!wordSynonyms.ContainsKey(word))
            {
                wordSynonyms.Add(word, new List<string>());
                wordSynonyms[word].Add(synonym);
            }
            else
            {
                wordSynonyms[word].Add(synonym);
            }
        }
        foreach (KeyValuePair<string, List<string>> entry in wordSynonyms )
        {
            Console.WriteLine(entry.Key +" - " +string.Join(", ", entry.Value));
        }
    }
}
