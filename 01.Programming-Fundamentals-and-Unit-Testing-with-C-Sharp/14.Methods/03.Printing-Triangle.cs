class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        PrintingTriangle(n);
    }
    static void PrintingTriangle(int n)
    {
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();
        }
        for (int i = n; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();
        }
    }
}
