string season = Console.ReadLine();
string accommodation = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

double pricePerNight = 1.00;
double discount = 0.00;

if (season == "Spring")
{
    discount = 1 - 0.20;
    if (accommodation == "Hotel")
    {
        pricePerNight = 30;
    }
    else
    {
        pricePerNight = 10;
    }
}
else if (season =="Summer")
{
    discount = 1;
    if (accommodation == "Hotel")
    {
        pricePerNight = 50;
    }
    else
    {
        pricePerNight = 30;
    }
}
else if (season == "Autumn")
{
    discount = 1-0.3;
    if (accommodation == "Hotel")
    {
        pricePerNight = 20;
    }
    else
    {
        pricePerNight = 15;
    }
}
else if (season == "Winter")
{
    discount = 1 - 0.1;
    if (accommodation == "Hotel")
    {
        pricePerNight = 40;
    }
    else
    {
        pricePerNight = 10;
    }
}

double totalCost = days * pricePerNight * discount;
Console.WriteLine($"{totalCost:F2}");
