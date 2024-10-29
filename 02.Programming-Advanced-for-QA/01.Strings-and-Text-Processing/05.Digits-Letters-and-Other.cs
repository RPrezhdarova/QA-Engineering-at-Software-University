using System.Text;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder sbDigits = new StringBuilder();
        StringBuilder sbLetters = new StringBuilder();
        StringBuilder sbOthers = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                sbLetters.Append(c);
            }
            else if (char.IsDigit(c))
            {
                sbDigits.Append(c);
            }
            else
            {
                sbOthers.Append(c);
            }
        }
        Console.WriteLine(sbDigits);
        Console.WriteLine(sbLetters);
        Console.WriteLine(sbOthers);
    }
}
