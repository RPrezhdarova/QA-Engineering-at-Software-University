class Programm
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int length = int.Parse(Console.ReadLine());
        
        int area = CalculateArea(width, length);
        Console.WriteLine(area);
    }
    static int CalculateArea(int w, int l)
    {
        int result = w * l;
        return result;
    }
}
