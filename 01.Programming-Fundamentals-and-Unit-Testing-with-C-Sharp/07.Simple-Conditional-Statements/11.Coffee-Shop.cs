string drink = Console.ReadLine();
string extra = Console.ReadLine();

decimal price = 0m;
if (drink == "tea")
{
    price =0.60m;
}
else
{
    price = 1.00m;
}
if (extra == "sugar")
{
    price += 0.40m;
}
Console.WriteLine($"Final price: ${price}"); 
