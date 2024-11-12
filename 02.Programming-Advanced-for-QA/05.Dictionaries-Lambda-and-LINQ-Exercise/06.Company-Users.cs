class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var companiesWithEmployees = new Dictionary<string, List<string>>();

        while(input!="End")
        {
            string[] inputProram = input.Split(" -> ");
            string company = inputProram[0];
            string employeeID = inputProram[1];

            if (companiesWithEmployees.ContainsKey(company))
            {
                if (!companiesWithEmployees[company].Contains(employeeID))
                {
                    companiesWithEmployees[company].Add(employeeID);
                }
            }
            else
            {
                companiesWithEmployees.Add(company, new List<string>(){employeeID});
            }
            input = Console.ReadLine();
        }
        foreach(KeyValuePair<string, List<string>> entry in companiesWithEmployees)
        {
            Console.WriteLine(entry.Key);
            foreach(var employee in entry.Value)
            {
                Console.WriteLine($"-- {employee}");
            }
        }
    }
}
