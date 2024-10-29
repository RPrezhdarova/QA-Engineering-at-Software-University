using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        Regex regexPhoneNumber = new Regex(@"[+]359([ -])2\1[0-9]{3}\1[0-9]{4}");
        MatchCollection allValidNumbers = regexPhoneNumber.Matches(text);
        Console.WriteLine(string.Join(", ", allValidNumbers));
    }
}
