char start = char.Parse(Console.ReadLine());
char end = char.Parse(Console.ReadLine());

for (int i = start; i <= end; i++)
{
    Console.Write($"{(char)i} ");
}
