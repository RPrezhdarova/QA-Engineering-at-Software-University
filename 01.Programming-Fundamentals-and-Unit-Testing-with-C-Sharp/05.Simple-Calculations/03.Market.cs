decimal tomatoPrice = decimal.Parse(Console.ReadLine());
decimal tomatoQuantity = decimal.Parse(Console.ReadLine());
decimal cucumberPrice = decimal.Parse(Console.ReadLine());
decimal cucumberQuantity = decimal.Parse(Console.ReadLine());

Console.WriteLine($"{tomatoPrice * tomatoQuantity + cucumberPrice * cucumberQuantity:F2}");
