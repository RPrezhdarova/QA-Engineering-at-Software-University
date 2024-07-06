class Program
{
    static void Main()
    {
        List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        for (int i = 1; i <= input.Count-1; i++)
        {
            if (input[i] == input[i - 1])
            {
                int newValue = input[i] * 2;
                input.Remove(input[i-1]);
                input.Remove(input[i-1]);
                input.Insert(i-1, newValue);
                i=0;
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine(string.Join(" ", input));
    }
}
