double radius = double.Parse(Console.ReadLine());
double area = radius * radius * Math.PI;
double perimeter = 2 * Math.PI * radius;
Console.WriteLine($"Area = {area:F2}");
Console.WriteLine($"Perimeter = {perimeter:F2}");
