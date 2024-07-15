class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int cumulativeIntake = 0;

        if (number <= 0)
        {
            Console.WriteLine("0");
        }
        else
        {
            for (int i = 0; i < number; i++)
            {
                int calories = int.Parse(Console.ReadLine());
                cumulativeIntake += calories;
                Console.WriteLine(cumulativeIntake);
            }           
        }
    }
}
