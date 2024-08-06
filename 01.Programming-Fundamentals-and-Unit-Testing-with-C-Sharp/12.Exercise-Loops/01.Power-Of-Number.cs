int n= int.Parse(Console.ReadLine());
int p= int.Parse(Console.ReadLine());
int j = n;
for (int i= 1; i < p; i++)
{
    n = j * n;
}
Console.WriteLine(n);
