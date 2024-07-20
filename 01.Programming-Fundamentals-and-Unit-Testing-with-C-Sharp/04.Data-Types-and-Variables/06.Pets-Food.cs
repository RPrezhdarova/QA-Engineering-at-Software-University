int dogFood = int.Parse(Console.ReadLine());
int catFood = int.Parse(Console.ReadLine());
double priceDogFood = 2.50;
double priceCatFood = 4.00;
double expenses = dogFood * priceDogFood + catFood * priceCatFood;

Console.WriteLine($"{expenses:F2} lv.");
