class Program
{
    static void Main()
    {
        int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        int[] secondArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        for (int i = 0; i < firstArray.Length; i++)
        {
            int currentNumber = firstArray[i];
            foreach (int number in secondArray)
            {
                if (currentNumber == number)
                {
                    Console.Write($"{number} ");
                    break;
                }
            }
        }       
    }
}
