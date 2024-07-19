class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    if (i*j*k == n)
                    {
                        Console.Write($"{i}{j}{k} ");
                    }
                }
            }
        }
    }
}
