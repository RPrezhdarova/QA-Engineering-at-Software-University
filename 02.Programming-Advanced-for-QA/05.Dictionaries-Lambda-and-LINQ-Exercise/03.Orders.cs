class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var products = new Dictionary<string, List<double>>();


        while (input != "buy")
        {
            string[] inputArray = input.Split(" ");
            string product = inputArray[0];
            double price = double.Parse(inputArray[1]);
            double quantity = double.Parse(inputArray[2]);

            if (!products.ContainsKey(product))
            {
                products.Add(product, new List<double>());
                products[product].Add(price);
                products[product].Add(quantity);
            }
            else
            {
                products[product][0] = price;
                products[product][1] += quantity;
            }

            input = Console.ReadLine();
        }
        foreach (KeyValuePair<string, List<double>> entry in products)
        {
            string product = entry.Key;
            double price = entry.Value[0];
            double quantity = entry.Value[1];
            double amount = price * quantity;

            Console.WriteLine($"{product} -> {amount:F2}");
        }
    }
}
