double bWidth = double.Parse(Console.ReadLine());
double bHeight = double.Parse(Console.ReadLine());
double tileW = double.Parse(Console.ReadLine());
double tileH = double.Parse(Console.ReadLine());

double bathArea = bWidth * bHeight;
double tileArea = tileW * tileH;
double bathSurplus = bathArea * 1.10;

Console.WriteLine($"{bathSurplus/ tileArea:F0}");
