class Program
{
    static void Main()
    {
        string type = Console.ReadLine();
        if (type == "int")
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(a, b));
        }
        else if ( type == "char")
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            Console.WriteLine((char)GetMax(a, b));
        }
        else
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Console.WriteLine(GetMax(a, b));
        }
    }
    static string GetMax(string a, string b) => a.CompareTo(b) > 0 ? a : b;    
    static char GetMax(char a, char b) => a > b ? a : b;    
    static int GetMax(int a, int b) => a > b ? a : b;
}
