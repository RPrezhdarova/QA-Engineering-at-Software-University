using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string patern = @"(?'day'\d{2})(?'del'[\/\.\-])(?'month'[A-Z][[a-z]{2})\'del'(?'year'\d{4})";
        Regex regex = new Regex(patern);
        MatchCollection matches = regex.Matches(text);
      
        foreach (Match match in matches)
        {
            string day = match.Groups["day"].Value;
            string month = match.Groups["month"].Value;
            string year = match.Groups["year"].Value;
          
            Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
        }
    }
}
