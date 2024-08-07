using System.Security.Cryptography;

int n = int.Parse(Console.ReadLine());
int newNumber = n;
bool isSpecial = false;

while( newNumber > 0 )
{
    int lastD = newNumber % 10;  
    if (n % lastD == 0)
    {
        isSpecial = true;       
    }
    else 
    {
        isSpecial = false;
        break;
    }
    newNumber = newNumber / 10; 
}
if (isSpecial)
{
    Console.WriteLine($"{n} is special");
}
else
{
    Console.WriteLine($"{n} is not special");
}
