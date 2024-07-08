class Program
{
    static void Main()
    {
        char startLetter= char.Parse(Console.ReadLine());
        char endLetter= char.Parse(Console.ReadLine());
        char excludedLetter= char.Parse(Console.ReadLine());

        int count = 0;
        for (int i = startLetter; i <= endLetter; i++) 
        {
            if (i == excludedLetter)
                continue;
            for (int j = startLetter; j <= endLetter; j++) 
            {
                if (j == excludedLetter)
                    continue;
                for (int k = startLetter; k <= endLetter; k++)
                {
                    if (k == excludedLetter)
                        continue;                    
                    Console.Write($"{(char)i}{(char)j}{(char)k} ");
                    count += 1;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine(count);
    }
}
