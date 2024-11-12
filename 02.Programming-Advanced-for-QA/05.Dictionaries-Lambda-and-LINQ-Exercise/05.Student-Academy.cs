class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Dictionary<string, double> studentsGrade = new Dictionary<string, double>();

        for (int i = 0; i < number; i++)
        {            
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if(!studentsGrade.ContainsKey(student))
            {
                studentsGrade.Add(student, grade);
            }
            else
            {
                double newGrade = (studentsGrade[student] + grade) / 2.00;
                studentsGrade[student] = newGrade;
            }
        }
        foreach(KeyValuePair<string, double> entry in  studentsGrade)
        {
            if (entry.Value >= 4.50)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value:F2}");
            }            
        }
    }
}
