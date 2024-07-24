int points = int.Parse(Console.ReadLine());

if (points>=0 && points <=3)
{
    points += 5;
    Console.WriteLine(points);
}
else if (points>=4 && points<=6)
{
    points += 15;
    Console.WriteLine(points);
}
else if (points>=7 && points<=9)
{
    points += 20;
    Console.WriteLine(points);
}
