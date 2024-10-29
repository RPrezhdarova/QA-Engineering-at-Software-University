using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string text=Console.ReadLine();
        
        Regex regexFullName = new Regex(@"\b[A-Z][a-z]+[ ][A-Z][a-z]+\b");
        MatchCollection allFullNames = regexFullName.Matches(text);  
        
        Console.WriteLine(string.Join(" ", allFullNames));
    }
}
