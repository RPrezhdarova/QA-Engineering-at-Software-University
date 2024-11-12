using System.Security.Cryptography;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                            .Split()
                            .ToArray();

            List<Student> studentsList = new List<Student>();

            while (input[0] != "end")
            {
                Student currentStudent = new Student { FirstName = input[0], LastName = input[1], Age = int.Parse(input[2]), HomeTown = input[3] };
                studentsList.Add(currentStudent);
                input = Console.ReadLine()
                            .Split()
                            .ToArray();
            }
            string town = Console.ReadLine();
            List<Student> filteredStudents = studentsList
                           .Where(s => s.HomeTown == town)
                           .ToList();
            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}