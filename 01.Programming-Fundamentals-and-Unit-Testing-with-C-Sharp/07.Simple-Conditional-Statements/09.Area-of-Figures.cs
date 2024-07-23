string figure = Console.ReadLine();

if (figure == "square")
{
    double side =double.Parse(Console.ReadLine());
    double are = side * side;
    Console.WriteLine($"{are:F2}");
}
if (figure == "rectangle")
{
    double width = double.Parse(Console.ReadLine());
    double length = double.Parse(Console.ReadLine());
    double area= width * length;
    Console.WriteLine($"{area:F2}");
}
if (figure == "circle")
{
    double radius = double.Parse(Console.ReadLine());  
    double area = Math.PI * radius * radius;
    Console.WriteLine($"{area:F2}");
}
