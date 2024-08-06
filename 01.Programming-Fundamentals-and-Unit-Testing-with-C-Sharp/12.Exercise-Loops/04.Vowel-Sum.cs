int n= int.Parse(Console.ReadLine());
int sum = 0;

for (int j=0; j<n; j++)
{
    char p= char.Parse(Console.ReadLine());
  
    switch (p)
    {
        case 'a':
            sum += 1;
            break;
        case 'e':
            sum += 2;
            break;
        case 'i':
            sum += 3;
            break;
        case 'o':
            sum += 4;
            break;
        case 'u':
            sum += 5;
            break;
    }
}
Console.WriteLine(sum);
