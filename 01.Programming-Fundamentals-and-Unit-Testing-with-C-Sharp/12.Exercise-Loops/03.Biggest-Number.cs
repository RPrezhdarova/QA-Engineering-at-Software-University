int n= int.Parse(Console.ReadLine());
int p = 0; 
int b = p;

for (int i= 0; i < n; i++)
{
  p = int.Parse(Console.ReadLine());  
    if (p>b)
    {
        b = p;
    }  
}
Console.WriteLine(b);
