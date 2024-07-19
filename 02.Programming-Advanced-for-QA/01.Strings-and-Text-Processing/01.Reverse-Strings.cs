class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        while(input!= "end")
        {
                string reversedText = "";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    char currentSymbol = input[i];
                    reversedText += currentSymbol;
                }
                Console.WriteLine(input + " = " + reversedText);
                input = Console.ReadLine();
        }
    }
}
