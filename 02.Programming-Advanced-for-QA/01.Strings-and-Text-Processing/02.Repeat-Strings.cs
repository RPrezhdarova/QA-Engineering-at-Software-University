using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(" ");
        string result = "";
        foreach(string word in words)
        {
            int length=word.Length;
            for(int count=1;count<=length;count++)
            {
                result += word;
            }
        }
        Console.WriteLine(result);
    }
}
