   int n = int.Parse(Console.ReadLine());
   int sum = 0;
   string expression = "";
   for (int a = 1; a <= n; a++)
   {
       sum += a;
       if (a == n)
       {
           expression += $"{a}=";
       }
       else
       {
           expression += $"{a}+";
       }    
   }
   Console.Write($"{expression}{sum}");
