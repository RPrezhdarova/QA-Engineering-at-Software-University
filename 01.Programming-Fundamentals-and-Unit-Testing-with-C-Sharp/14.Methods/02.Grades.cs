using System.Diagnostics.Contracts;

class Program
{
    static void Main()
    {
        double grade = double.Parse(Console.ReadLine());
        GradeInWords(grade);
    }
    static void GradeInWords(double grade)
    {
        switch (grade)
        {
            case >= 2 and <= 2.99:
                Console.WriteLine("Fail");
                break;
            case >= 3 and <= 3.49:
                Console.WriteLine("Average");
                break;
            case >= 3.50 and <= 4.49:
                Console.WriteLine("Good");
                break;
            case >= 4.50 and <= 5.49:
                Console.WriteLine("Very good");
                break;
            case >= 5.50 and <= 6.00:
                Console.WriteLine("Excellent");
                break;
        }
    }
}
