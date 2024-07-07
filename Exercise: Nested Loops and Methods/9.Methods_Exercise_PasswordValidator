class Program
{
    static void Main()
    {
        string password = Console.ReadLine();
        if (!CheckPassBetweenSixAndTenCharacters(password))
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }
        if (!CheckPassContainsOnlyLettersAndDigits(password))
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }
        if (!CheckPassMinDigit(password))
        {
            Console.WriteLine("Password must have at least 2 digits");
        }
        if (CheckPassBetweenSixAndTenCharacters(password) && CheckPassContainsOnlyLettersAndDigits(password) && CheckPassMinDigit(password))
        {
            Console.WriteLine("Password is valid");
        }
    }
    static bool CheckPassBetweenSixAndTenCharacters(string pass)
    {
        if(pass.Length >= 6 && pass.Length <= 10)
        {
            return true;
        }
        return false;
    }
    static bool CheckPassContainsOnlyLettersAndDigits(string pass)
    {
        for(int i = 0; i< pass.Length; i++)
        {
            char currChar = pass[i];
                if (!char.IsLetterOrDigit(currChar))
            {
                return false;
            }
        }
        return true;
    }
    static bool CheckPassMinDigit(string pass)
    {
        int counter = 0;
        for (int i = 0;i< pass.Length;i++) 
        {
            char currChar = pass[i];
            if (char.IsDigit(currChar))
            {
                counter++;
                if (counter >= 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
 }
