namespace Players;

public class Hero
{
    private string userName;
    private int level;

    public Hero(string userName, int level)
    {
        UserName = userName;
        Level = level;
    }

    public string UserName { get; set; }
    public int Level { get; set; }

    public override string ToString()
    {
        return $"Type: {GetType().Name} Username: {UserName} Level: {Level}";
    }
}
