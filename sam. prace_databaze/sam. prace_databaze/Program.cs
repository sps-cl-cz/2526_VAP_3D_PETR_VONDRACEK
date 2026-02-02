using System;
using Microsoft.Data.Sqlite;

class Program
{
    static string connectionString = "Data Source=notes.db";

    static void Main()
    {
        CreateTable();

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Přidat nový záznam");
            Console.WriteLine("2 - Vypsat všechny záznamy");
            Console.WriteLine("3 - Smazat záznam podle ID");
            Console.WriteLine("4 - Ukončit aplikaci");
            Console.Write("Vyber možnost: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNote();
                    break;
                case "2":
                    ShowNotes();
                    break;
                case "3":
                    DeleteNote();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }
    }

    // vytvoření tabulky
    static void CreateTable()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Notes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Description TEXT NOT NULL
            );
        ";

        command.ExecuteNonQuery();
    }

    // přidání záznamu
    static void AddNote()
    {
        Console.Write("Zadej název: ");
        string title = Console.ReadLine();

        Console.Write("Zadej popis: ");
        string description = Console.ReadLine();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Notes (Title, Description)
            VALUES (@title, @description);
        ";

        command.Parameters.AddWithValue("@title", title);
        command.Parameters.AddWithValue("@description", description);

        command.ExecuteNonQuery();
        Console.WriteLine("Záznam byl uložen.");
    }

    // výpis záznamů
    static void ShowNotes()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Notes;";

        using var reader = command.ExecuteReader();

        Console.WriteLine("\n--- SEZNAM POZNÁMEK ---");

        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader.GetInt32(0)}");
            Console.WriteLine($"Název: {reader.GetString(1)}");
            Console.WriteLine($"Popis: {reader.GetString(2)}");
            Console.WriteLine("-----------------------");
        }
    }

    // mazání záznamu
    static void DeleteNote()
    {
        Console.Write("Zadej ID záznamu ke smazání: ");
        int id = int.Parse(Console.ReadLine());

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Notes WHERE Id = @id;";
        command.Parameters.AddWithValue("@id", id);

        int rows = command.ExecuteNonQuery();

        if (rows > 0)
            Console.WriteLine("Záznam byl smazán.");
        else
            Console.WriteLine("Záznam s tímto ID neexistuje.");
    }
}
