int nylonAmount = int.Parse(Console.ReadLine());
int paintAmount = int.Parse(Console.ReadLine());
int thinnerQuantity = int.Parse(Console.ReadLine());
int craftsmenHours = int.Parse(Console.ReadLine());

double nylonCosts = (nylonAmount + 2) * 1.50;
double paintCosts = (paintAmount * 1.1) * 14.50;
double thinnerCosts = thinnerQuantity * 5;
double bags = 0.40;
double totalCostsWC = nylonCosts + paintCosts + thinnerCosts + bags;
double craftsmenCosts = (totalCostsWC * 0.3) * craftsmenHours;
double totalCosts = totalCostsWC + craftsmenCosts;

Console.WriteLine(totalCosts);
