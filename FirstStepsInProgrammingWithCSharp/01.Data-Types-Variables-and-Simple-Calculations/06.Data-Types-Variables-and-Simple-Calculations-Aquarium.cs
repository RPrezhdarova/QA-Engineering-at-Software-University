int lenght = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());
double percentOccupiedSpace = double.Parse(Console.ReadLine());

double volumeAquarium = lenght * width * height;
double volumeLiters = volumeAquarium * 0.001;
double requiredLiters = volumeLiters * (1 - percentOccupiedSpace / 100);

Console.WriteLine($"{requiredLiters:F2}");
