decimal depositedAmount = decimal.Parse(Console.ReadLine());
int depositTerm = int.Parse(Console.ReadLine());
decimal interestRate = decimal.Parse(Console.ReadLine());

decimal amount = depositedAmount + depositTerm * depositedAmount * interestRate / 1200 ;
Console.WriteLine($"{amount:F2}");
