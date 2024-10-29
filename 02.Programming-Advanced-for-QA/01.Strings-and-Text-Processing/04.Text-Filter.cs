class Program
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Split(", ");
        string text =Console.ReadLine();

        foreach (string banWord in bannedWords)
        {
            string replacement = string.Empty;
            for(int star=1; star<= banWord.Length; star++)
            {
                replacement += "*";
            }
            text= text.Replace(banWord, replacement);
        }
        Console.WriteLine(text);
    }
}
