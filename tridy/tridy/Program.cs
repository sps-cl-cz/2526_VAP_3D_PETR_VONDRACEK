/*

using System;
using System.Collections.Generic;
using System.IO;

namespace tridy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Nedostatecny pocet argumentu");
                return;
            }

            string operation = args[0].ToLower().Trim();
            string title = args[1];
            bool completed = args[2].ToLower().Trim() == "splneno";

            if (operation == "pridat")
            {
                MyTask task = new MyTask(title, completed);

                string[] lines = File.Exists("tasks.txt") ? File.ReadAllLines("tasks.txt") : new string[0];

                Dictionary<int, MyTask> tasks = ParseFiles(lines);
                tasks.Add(task.Id, task);

                File.WriteAllLines("tasks.txt", TasksToString(tasks));
                break;
                case "zobrazit":
                    foreach(MyTask myTask in tasks.Values)
                    {
                        Console.WriteLine(myTask);
                    }
                    break;

                    else if (operation == "smazat")
                    {
                        int id = int.Parse(args[1]);

                        string[] lines = File.Exists("tasks.txt") ? File.ReadAllLines("tasks.txt") : new string[0];
                        Dictionary<int, MyTask> tasks = ParseFiles(lines);

                        if (tasks.ContainsKey(id))
                        {
                            tasks.Remove(id);
                            File.WriteAllLines("tasks.txt", TasksToString(tasks));
                            Console.WriteLine($"Úkol s ID {id} byl smazán.");
                        }
                        else
                        {
                            Console.WriteLine($"Úkol s ID {id} neexistuje.");
                        }
                    }

                }
            }

        static List<string> TasksToString(Dictionary<int, MyTask> tasks)
        {
            List<string> result = new List<string>();

            foreach (MyTask value in tasks.Values)
            {
                result.Add(value.ToString());
            }

            return result;
        }

        static Dictionary<int, MyTask> ParseFiles(string[] lines)
        {
            Dictionary<int, MyTask> dictionary = new Dictionary<int, MyTask>();

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split(",");

                    string title = parts[0].Split(":")[1].Trim();
                    bool completed = parts[1].Split(":")[1].Trim() == "True";
                    int id = int.Parse(parts[2].Split(":")[1].Trim());

                    MyTask task = new MyTask(title, completed);
                    task.Id = id;

                    dictionary.Add(task.Id, task);
                }
                catch
                {
                }
            }

            return dictionary;
        }
    }

    class MyTask
    {
        private static int lastId = 0;

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public MyTask(string title, bool completed)
        {
            Id = ++lastId;
            Title = title;
            Completed = completed;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Completed: {Completed}, Id: {Id}";
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace tridy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Nedostatecny pocet argumentu");
                return;
            }

            string operation = args[0].ToLower().Trim();

            if (operation == "pridat")
            {
                if (args.Length < 3)
                {
                    Console.WriteLine("Chybi nazev nebo stav");
                    return;
                }

                string title = args[1];
                bool completed = args[2].ToLower().Trim() == "splneno";

                MyTask task = new MyTask(title, completed);

                string[] lines = File.Exists("tasks.txt") ? File.ReadAllLines("tasks.txt") : new string[0];
                Dictionary<int, MyTask> tasks = ParseFiles(lines);

                tasks.Add(task.Id, task);
                File.WriteAllLines("tasks.txt", TasksToString(tasks));

                Console.WriteLine($"Ukol pridan s ID {task.Id}");
            }
            else if (operation == "smazat")
            {
                int id = int.Parse(args[1]);

                string[] lines = File.Exists("tasks.txt") ? File.ReadAllLines("tasks.txt") : new string[0];
                Dictionary<int, MyTask> tasks = ParseFiles(lines);

                if (tasks.ContainsKey(id))
                {
                    tasks.Remove(id);
                    File.WriteAllLines("tasks.txt", TasksToString(tasks));
                    Console.WriteLine($"Ukol s ID {id} byl smazan.");
                }
                else
                {
                    Console.WriteLine($"Ukol s ID {id} neexistuje.");
                }
            }
            else
            {
                Console.WriteLine("Neznama operace. Pouzij: pridat | smazat");
            }
        }

        static List<string> TasksToString(Dictionary<int, MyTask> tasks)
        {
            List<string> result = new List<string>();

            foreach (MyTask value in tasks.Values)
            {
                result.Add(value.ToString());
            }

            return result;
        }

        static Dictionary<int, MyTask> ParseFiles(string[] lines)
        {
            Dictionary<int, MyTask> dictionary = new Dictionary<int, MyTask>();

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split(",");

                    string title = parts[0].Split(":")[1].Trim();
                    bool completed = parts[1].Split(":")[1].Trim() == "True";
                    int id = int.Parse(parts[2].Split(":")[1].Trim());

                    MyTask task = new MyTask(title, completed);
                    task.Id = id;

                    dictionary.Add(task.Id, task);
                }
                catch
                {
                }
            }

            return dictionary;
        }
    }

    class MyTask
    {
        private static int lastId = 0;

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public MyTask(string title, bool completed)
        {
            Id = ++lastId;
            Title = title;
            Completed = completed;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Completed: {Completed}, Id: {Id}";
        }
    }
}
