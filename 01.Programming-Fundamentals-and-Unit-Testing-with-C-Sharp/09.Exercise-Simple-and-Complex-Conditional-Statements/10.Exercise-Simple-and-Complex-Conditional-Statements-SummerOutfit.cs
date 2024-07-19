int temperature = int.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();

string outfit = " ";
string shoes = " ";

if (temperature >= 10 && temperature <= 18)
{
   switch (timeOfDay)
    { 
    case "Afternoon":
    case "Evening":
        outfit = "Shirt";
        shoes = "Moccasins";
        break;
    case "Morning":
        outfit = "Sweatshirt";
        shoes = "Sneakers";
        break;
    }
}
else if (temperature > 18 && temperature <= 24)
{
     switch (timeOfDay)
        { 
     case "Afternoon":
        outfit = "T-Shirt";
        shoes = "Sandals";
            break;
     case "Morning":
     case "Evening":            
        outfit = "Shirt";
        shoes = "Moccasins";
            break;
}
    }
    else if (temperature >= 25)
{
        switch (timeOfDay)
        { 
        case "Morning":
        outfit = "T-Shirt";
        shoes = "Sandals";
            break;
            case "Afternoon":
        outfit = "Swim Suit";
        shoes = "Barefoot";
                break;
        case "Evening":    
        outfit = "Shirt";
        shoes = "Moccasins";
                break;
        }
    }
Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
