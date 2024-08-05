int number = int.Parse(Console.ReadLine());
string command = "";

while ((command = Console.ReadLine()) != "End")
{
    if (command == "Inc")
    {
        number++;
    }
    else if ( command == "Dec")
    {
        number--;
    }
}
Console.WriteLine(number);  
