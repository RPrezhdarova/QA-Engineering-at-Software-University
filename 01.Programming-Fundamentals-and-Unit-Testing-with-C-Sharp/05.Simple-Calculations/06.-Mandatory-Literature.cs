int pages = int.Parse(Console.ReadLine());
int pagesPerHour = int.Parse(Console.ReadLine());  
int days = int.Parse(Console.ReadLine());

int readingHours = pages / pagesPerHour;
int hoursPerdDay = readingHours / days;

Console.WriteLine($"{hoursPerdDay}");
