class Program
{
    static void Main()
    {
        int[] firstSequence = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();
        int[] secondSequence = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        int[] lastList = new int[firstSequence.Length + secondSequence.Length];
        int j = 0;
        for (int i = 0; i < lastList.Length; i++)
        {
            if (secondSequence.Length <= firstSequence.Length)
            {
                lastList[i] = firstSequence[j];

                if (j < secondSequence.Length)
                {
                    lastList[i + 1] = secondSequence[j];
                    i++;

                }
            }

            if (secondSequence.Length > firstSequence.Length)
            {
                
                if (j < firstSequence.Length)
                {
                    lastList[i + 1] = secondSequence[j];
                    lastList[i] = firstSequence[j];
                    i++;

                }
                if (j >= firstSequence.Length)
                {
                    lastList[i] = secondSequence[j];
                }

            }

            j++;

        }
        Console.WriteLine(string.Join(" ", lastList));

    }
}
