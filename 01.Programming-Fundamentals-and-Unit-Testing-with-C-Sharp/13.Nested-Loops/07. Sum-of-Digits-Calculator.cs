while (true)
{
    string n = Console.ReadLine();
    int sum = 0;
    if (n == "End")
    {
        Console.WriteLine("Goodbye");
        break;
    }
    else
    {
        int a = int.Parse(n);
        while (a != 0)
        {
            int digit = a % 10;
            sum += digit;
            a = a / 10;            
        }
        Console.WriteLine($"Sum of digits = {sum}");
    }
}
