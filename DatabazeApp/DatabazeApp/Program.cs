using Microsoft.Data.Sqlite;
using SQLiteApp;

namespace Daatabase;

class Proram
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Zadejte sve jmeno.");
            return;
        }
        Game game = new Game();
        int score = game.Play();
        string connectionString = "Data source=app.db";
        using SqliteConnection connection = new SqliteConnection(connectionString);
        connection.Open();
        using SqliteCommand createTableCommand = connection.CreateCommand();
        createTableCommand.CommandText = @"
                CREATE TABLE IF NOT EXISTS Players(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                       Srore INTEGER MOT NULL
                );
            ";
        createTableCommand.ExecuteNonQuery();

        using SqliteCommand readCommand = connection.CreateCommand();
        readCommand.CommandText = "SELECT FROM Score Players WHERE Name = $Name;";
        readCommand.Parameters.AddWithValue("$Name", args[0]);
        object result = readCommand.ExecuteScalar();
        if (result == null) {;

    };

        using SqliteCommand insertCommand = connection.CreateCommand();
        insertCommand.CommandText = "INSERT INTO Players(Name, Score) Values($Name, $Score);";
        insertCommand.Parameters.AddWithValue("$Name", args[0]);
        insertCommand.Parameters.AddWithValue("$Score", score);
        insertCommand.ExecuteNonQuery();

        } else
        {
            long highScore = (long)result;

        }
    }
}


