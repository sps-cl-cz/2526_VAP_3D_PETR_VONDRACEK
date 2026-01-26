using DatabaseApp1;

class Program
{

    public static void Main(string[] args)
    {
        string name;
        if (args.Length == 0)
        {
            Console.WriteLine("Zadejte sve jmeno.");
            name = Console.ReadLine();
        } else
            name = args[0];

        int score = new Game().Play();
        using SQLiteContext context = new SQLiteContext();
        context.Database.EnsureCreated();
        Player player = context.Player.FirstOrDefault(p => p.Name ==name);
        if (player == null)
        {
            player = new Player();
            {
                Name = name,
                HighScore = score,
            };
            context.Player.Add(player);
        } else
        {
            player.HighScore = Math.Max(score, player.HighScore);
        }
        context.SaveChanges();
    }
}

