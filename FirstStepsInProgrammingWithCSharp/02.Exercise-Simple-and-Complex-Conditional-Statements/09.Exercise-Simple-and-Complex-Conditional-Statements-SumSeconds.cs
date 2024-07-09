int first = int.Parse(Console.ReadLine());
int second = int.Parse(Console.ReadLine());
int third = int.Parse(Console.ReadLine());

int minutes = (first + second + third) / 60;
int seconds = (first + second + third) - minutes*60;

if (seconds >=10)
{
    Console.WriteLine($"{minutes}:{seconds}");
}
else 
{
    Console.WriteLine($"{minutes}:0{seconds}");
}
