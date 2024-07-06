using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> firstPlayerCards = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
        List<int> secondPlayerCards = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

        while(firstPlayerCards.Count!=0 && secondPlayerCards.Count!=0)
        {
            int i = 0;
            if( firstPlayerCards[i] == secondPlayerCards[i] )
            {
                firstPlayerCards.Remove(firstPlayerCards[i]);
                secondPlayerCards.Remove(secondPlayerCards[i]);
            }
            else if (firstPlayerCards[i] > secondPlayerCards[i])
            {            
                firstPlayerCards.Add(firstPlayerCards[i]);
                firstPlayerCards.Add(secondPlayerCards[i]);
                firstPlayerCards.Remove(firstPlayerCards[i]);
                secondPlayerCards.Remove(secondPlayerCards[i]);
            }
            else if (firstPlayerCards[i] < secondPlayerCards[i])
            {
                secondPlayerCards.Add(secondPlayerCards[i]);
                secondPlayerCards.Add(firstPlayerCards[i]);
                secondPlayerCards.Remove(secondPlayerCards[i]);
                firstPlayerCards.Remove(firstPlayerCards[i]);
            }
        }
        int sum = 0;
        if(firstPlayerCards.Count == 0)
        {
            for(int i=0; i< secondPlayerCards.Count; i++)
            {
                sum += secondPlayerCards[i];
            }
            Console.WriteLine($"Second player wins! Sum: {sum}");
        }
        else
        {
            for (int i = 0; i < firstPlayerCards.Count; i++)
            {
                sum += firstPlayerCards[i];
            }
            Console.WriteLine($"First player wins! Sum: {sum}");
        }
    }
}
