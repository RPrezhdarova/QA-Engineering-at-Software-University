class Program
{
    static void Main()
    {
        List<int> input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToList();

        List<int> topIntegers = new List<int>();
        int count = 0;
        bool isMoreThen = false;

        for (int i = 0; i < input.Count-1; i++)
        {
            for (int j = i + 1; j < input.Count; j++)
            {
                if (input[i] > input[j])
                {
                    isMoreThen = true;
                    continue;
                }
                else
                {
                    isMoreThen = false;
                    break;
                }
            }
            if (isMoreThen == true)
            {
                topIntegers.Add(input[i]);
            }
        }
        topIntegers.Add(input[input.Count-1]);
        Console.Write(string.Join(" ", topIntegers));
    }
}
