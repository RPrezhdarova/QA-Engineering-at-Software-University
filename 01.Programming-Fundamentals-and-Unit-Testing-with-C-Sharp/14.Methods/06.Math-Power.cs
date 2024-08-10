class Program
{
    static void Main()
    {
        int baseNumber = int.Parse (Console.ReadLine());
        int power = int.Parse (Console.ReadLine());
        int result = Pow(baseNumber, power);
        Console.WriteLine (result);
    }
    static int Pow(int baseNumber, int power)
    {
        int result = baseNumber;
        for (int i = 2; i<= power; i++)
        {
            result *= baseNumber;
        }
        return result;
    }
}
