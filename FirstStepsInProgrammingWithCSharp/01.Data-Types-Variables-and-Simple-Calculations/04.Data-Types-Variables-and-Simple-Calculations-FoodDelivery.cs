int countOfChickenMenus = int.Parse(Console.ReadLine());
int countOfFishMenus = int.Parse(Console.ReadLine());
int countOfVegetarianMenus = int.Parse(Console.ReadLine());


double priceForOneChickenMenu = 10.35;
double priceForOneFishMenu = 12.40;
double priceForOneVegetarianMenu = 8.15;

double priceAllChickenMenus = countOfChickenMenus * priceForOneChickenMenu;
double priceAllFishMenus = countOfFishMenus * priceForOneFishMenu; 
double priceAllVegetarianMenus = countOfVegetarianMenus * priceForOneVegetarianMenu;

double costAllMenus = priceAllChickenMenus + priceAllFishMenus + priceAllVegetarianMenus;
double dessert = costAllMenus * 0.2;
double costDelivery = 2.50;

double totalCost = costAllMenus + costDelivery + dessert;

Console.WriteLine(totalCost);
