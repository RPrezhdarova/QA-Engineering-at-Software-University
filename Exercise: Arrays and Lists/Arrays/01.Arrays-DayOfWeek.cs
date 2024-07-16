class Program
{
    static void Main()
    {
       string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
       int dayIndex = int.Parse(Console.ReadLine());
        dayIndex -= 1;
        if (dayIndex < 0 || dayIndex>=7)
        {
            Console.WriteLine("Invalid day!");
        }
        else
        {
            Console.WriteLine(days[dayIndex]);
        }        
    }
}
