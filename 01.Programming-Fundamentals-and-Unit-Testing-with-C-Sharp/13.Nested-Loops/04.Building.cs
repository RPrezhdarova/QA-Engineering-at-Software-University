int floor = int.Parse(Console.ReadLine());
int number = int.Parse(Console.ReadLine());

 for (int i = 0; i < number; i++)
    {
        Console.Write($" L{floor}{i}");
    }
    Console.WriteLine();
floor--;

for (; floor>=1 && number>=0; floor--)
{
    if (floor % 2 == 0)
    {
        for (int i = 0; i < number; i++)
        {
            Console.Write($" O{floor}{i}");
        }
        Console.WriteLine();       
    }   
    if (floor % 2 != 0)
    {
       for (int i = 0; i < number; i++)
        {
            Console.Write($" A{floor}{i}");
        }
        Console.WriteLine();
    }    
}
