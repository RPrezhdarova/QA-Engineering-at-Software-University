string enter = Console.ReadLine();
double balance = 0;

while (enter != "End")
{
   double amount = double.Parse(enter);
    if (amount > 0)
    {
        balance += amount;
        Console.WriteLine($"Increase: {amount:F2}");
    }
    else
    {
        balance += amount;
        Console.WriteLine($"Decrease: {Math.Abs(amount):F2}");
    }
    enter = Console.ReadLine();
}
Console.WriteLine($"Balance: {balance:F2}");
