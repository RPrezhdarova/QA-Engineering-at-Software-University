class Program
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        Console.WriteLine((FindFactorialOfNumber(firstNum)) / (FindFactorialOfNumber(secondNum)));
    }
    static int FindFactorialOfNumber(int num)
    {
        int factorial = 1;
        for (int i = 1; i <= num; i++) {
            factorial *= i;
        }
        return factorial;
    }
}
