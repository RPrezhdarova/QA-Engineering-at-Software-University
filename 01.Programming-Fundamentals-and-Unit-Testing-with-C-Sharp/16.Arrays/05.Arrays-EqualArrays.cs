class Program
{
    static void Main()
    {
        int[]firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        int[]secondArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        for (int i = 0; i < firstArray.Length; i++) 
        {
           if (firstArray[i] != secondArray[i])
            {                
                Console.WriteLine("Arrays are not identical.");
                return;
            }            
        }
        Console.WriteLine("Arrays are identical.");
    }
}
