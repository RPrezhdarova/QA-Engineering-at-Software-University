decimal packagePensPrice = 5.80m;
decimal packageMarkersPrice = 7.20m;
decimal boardCleanerPriceLiter = 1.20m;

double penPackages = double.Parse(Console.ReadLine());
double markerPackages = double.Parse(Console.ReadLine());
double boardCleanerLiters = double.Parse(Console.ReadLine());  
double discount = double.Parse(Console.ReadLine());

decimal penPackagesPrice = (decimal)penPackages * packagePensPrice;
decimal markerPackagesPrice = (decimal)markerPackages * packageMarkersPrice;
decimal boardCleanerPrice = (decimal)boardCleanerLiters * boardCleanerPriceLiter;

decimal totalCost = penPackagesPrice + markerPackagesPrice + boardCleanerPrice;
decimal totalCostAfterDiscount = totalCost - totalCost * (decimal)discount/100;

Console.WriteLine($"{totalCostAfterDiscount:F2}");
