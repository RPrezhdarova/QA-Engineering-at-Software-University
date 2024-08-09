while (true)
{    
    string destination = Console.ReadLine();
    if (destination == "End")
    {
        break;
    }
    double budget = int.Parse(Console.ReadLine());
    double sum = 0;
  
    while (sum < budget)
{
        double money = int.Parse(Console.ReadLine());
        sum += money;
        if (sum < budget)
        {
            Console.WriteLine($"Collected: {sum:F2}");            
        }
        else
        {
            Console.WriteLine($"Collected: {sum:F2}");
            Console.WriteLine($"Going to {destination}!");
        }
    }
    budget = 0;
}
