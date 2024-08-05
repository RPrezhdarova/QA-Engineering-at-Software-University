int n = int.Parse(Console.ReadLine());
int i = 0;
int sum = 0;
while (n / 10 >0)
   {
    i = n % 10;
    sum += i;
    n = n / 10;
    }
Console.WriteLine(sum+n);
