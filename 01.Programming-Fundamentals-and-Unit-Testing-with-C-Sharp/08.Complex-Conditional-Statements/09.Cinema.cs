string movieType = Console.ReadLine();
int rows = int.Parse(Console.ReadLine());
int seats = int.Parse(Console.ReadLine());

int totalSeats = rows * seats;
double moviePrice = 0;

if (movieType == "Premiere")
{
   moviePrice = 12.00;
}
else if (movieType == "Normal")
    {
   moviePrice = 7.50;
    }
else if (movieType == "Discount")
{
    moviePrice = 5.00;
}

double totalCost = totalSeats * moviePrice;
Console.WriteLine($"{totalCost:F2}");
