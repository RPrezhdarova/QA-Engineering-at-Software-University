class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int value = 0;
        int count = 0;
        int buffer = 0;
        int lenght = 0;
        int print_output = 0;

        List<int> list = new List<int>();
        for (int i = 0; i <= input.Length - 1; i++)
        {
            value = input[i];
            if (buffer == value)
            {
                count++;
            }
            else
            {                
                count = 1;
                buffer = value;
            }
            if (lenght < count)
            {
                print_output = buffer;
                lenght = count;
            }
        }
        for (int j = 0; j <= lenght - 1; j++)
        {
            list.Add(print_output);
        }
        Console.WriteLine(string.Join(" ", list));
    }
}
