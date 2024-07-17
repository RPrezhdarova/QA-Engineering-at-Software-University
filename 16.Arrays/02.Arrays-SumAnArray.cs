class Program
{
    static void Main()
    {      
        int[] splittedLine = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        int sum = 0;

        for (int i = 0; i < splittedLine.Length; i++)
        {
            sum += splittedLine[i];
        }
        Console.WriteLine(sum);
    }
}
