class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        PrintVowelsCountInText(input);
    }
    static void PrintVowelsCountInText(string text)
    {
        int counter = 0;    
        for (int i = 0; i < text.Length; i++) 
        {
            char currentLetter = text[i];
            switch (currentLetter)
            {
                   case 'a': counter++; break;
                   case 'o': counter++; break;
                   case 'u': counter++; break;
                   case 'i': counter++; break;
                   case 'e': counter++; break;
                   case 'A': counter++; break;
                   case 'O': counter++; break;
                   case 'U': counter++; break;
                   case 'I': counter++; break;
                   case 'E': counter++; break;
            }
        }
        Console.WriteLine(counter);
    }
}
