class Program
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        PrintMultiplicationSign(num1, num2, num3);
    }
    static void PrintMultiplicationSign(int num1, int num2, int num3)
    {
        if (num1*num2*num3 == 0)
        {
            Console.WriteLine("zero");
        }
        else if( num1*num2*num3 > 0)
        {
            Console.WriteLine("positive");
        }
        else 
        {
            Console.WriteLine("negative");
        }
    }
}
