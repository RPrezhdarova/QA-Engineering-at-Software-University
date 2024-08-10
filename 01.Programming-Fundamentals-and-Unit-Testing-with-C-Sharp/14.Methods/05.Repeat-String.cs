class Program
{
    static void Main()
    {
        string text= Console.ReadLine();
        int count = int.Parse(Console.ReadLine());
        string repeatedString = Repeat(text, count);
        Console.WriteLine(repeatedString);
    }
    static string Repeat(string text, int count)
    {
        string result = "";
        for (int i = 1; i<= count; i++)
        {
            result += text;
        }
        return result;
    }
}
