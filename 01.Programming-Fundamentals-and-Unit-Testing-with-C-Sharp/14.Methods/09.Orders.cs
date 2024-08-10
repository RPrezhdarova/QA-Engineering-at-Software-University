class Program
{
    static void Main()
    {
        string product = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());
        double totalCost= TotalPriceOfTheOrder(product, quantity);
        Console.WriteLine(($"{totalCost:F2}"));
    }
    static double TotalPriceOfTheOrder(string product, int quantity)
    {
        double result = 0;
        double price = 0;
        double totalCost = 0;
        switch(product)
        {   
            case "coffee": price = 1.50; break;
            case "water": price = 1.00; break;
            case "coke": price = 1.40; break;
            case "snacks": price = 2.00; break;
        }
        totalCost = price * quantity;
        return totalCost;
    }
}
