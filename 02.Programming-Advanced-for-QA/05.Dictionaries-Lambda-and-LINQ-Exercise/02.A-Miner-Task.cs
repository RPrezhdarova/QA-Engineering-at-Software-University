class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int quontity = 0;
        Dictionary<string, int> resourceQuontity = new Dictionary<string, int>();        

        while (input != "stop")
        {
            quontity = int.Parse(Console.ReadLine());         

            if (input == "stop")
            {
                break;
            }
            
            if (resourceQuontity.ContainsKey(input))
            {
                resourceQuontity[input] += quontity;
            }
            else
            {               
                resourceQuontity.Add(input, quontity);
            }
            input = Console.ReadLine();        
        }
        foreach (KeyValuePair<string, int> entry in resourceQuontity)
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }
    }
}
