int stopNumber= int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());
int previousNumber = 0;

while (n != stopNumber)
{
    n = int.Parse(Console.ReadLine());  
    if (n == stopNumber)
    {
        break;
    }
    else
    {
        previousNumber = n;
    }
}
double p = previousNumber * 1.20;
Console.WriteLine(p);
