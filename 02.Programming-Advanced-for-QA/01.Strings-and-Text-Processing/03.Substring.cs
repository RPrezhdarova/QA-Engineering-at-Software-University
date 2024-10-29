class Program
{
    static void Main()
    {
        string wordToRemove = Console.ReadLine();
        string text = Console.ReadLine();
        while (text.IndexOf(wordToRemove) != -1)
        {
            text = text.Remove(text.IndexOf(wordToRemove), wordToRemove.Length);
        }
        Console.WriteLine(text);
    }
}
