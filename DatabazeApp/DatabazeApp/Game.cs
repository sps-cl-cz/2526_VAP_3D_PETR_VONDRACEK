using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp
{
    public class Game
    {
        public Game() 
        {
            playerX = width / 2;
        }
        int width = 60;
        int height = 25;

        int playerX = 0;
        int score = 0;
        bool gameOver = false;

        List<(int x, int y)> bullets = new();
        List<(int x, int y)> enemies = new();

        int enemyDirection = 1;

        Dictionary<ConsoleKey, int> pressedKeys = new();

        public int Play()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            InitEnemies();

            while (!gameOver)
            {
                ProcessInput();
                UpdateGame();
                DrawGame();
                Thread.Sleep(80);
            }

            Console.Clear();
            Console.SetCursorPosition(width / 2 - 5, height / 2);
            Console.Write("GAME OVER");
            Console.SetCursorPosition(width / 2 - 7, height / 2 + 1);
            Console.Write($"Score: {score}");
            Console.ReadKey();
            return score;
        }

        void InitEnemies()
        {
            enemies.Clear();
            for (int y = 2; y < 6; y++)
            {
                for (int x = 10; x < width - 10; x += 4)
                {
                    enemies.Add((x, y));
                }
            }
        }
        void ProcessInput()
        {
            foreach (ConsoleKey key in pressedKeys.Keys)
            {
                int value = pressedKeys[key];
                pressedKeys[key] = Math.Max(--value, 0);
            }
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                pressedKeys[key] = 5;
            }

            if (IsPressed(ConsoleKey.LeftArrow) && playerX > 1)
                playerX--;

            if (IsPressed(ConsoleKey.RightArrow) && playerX < width - 2)
                playerX++;

            if (IsPressed(ConsoleKey.Spacebar))
                bullets.Add((playerX, height - 3));

            if (IsPressed(ConsoleKey.Escape))
                gameOver = true;
        }

        bool IsPressed(ConsoleKey key)
        {
            if (pressedKeys.TryGetValue(key, out int value))
            {
                return value > 0;
            }
            return false;
        }

        void UpdateGame()
        {
            // Pohyb střel
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i] = (bullets[i].x, bullets[i].y - 1);
                if (bullets[i].y < 1)
                    bullets.RemoveAt(i);
            }

            // Pohyb nepřátel
            bool changeDirection = false;
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i] = (enemies[i].x + enemyDirection, enemies[i].y);

                if (enemies[i].x <= 1 || enemies[i].x >= width - 2)
                    changeDirection = true;
            }

            if (changeDirection)
            {
                enemyDirection *= -1;
                for (int i = 0; i < enemies.Count; i++)
                    enemies[i] = (enemies[i].x, enemies[i].y + 1);
            }

            // Kolize
            for (int b = bullets.Count - 1; b >= 0; b--)
            {
                for (int e = enemies.Count - 1; e >= 0; e--)
                {
                    if (bullets[b].x == enemies[e].x &&
                        bullets[b].y == enemies[e].y)
                    {
                        bullets.RemoveAt(b);
                        enemies.RemoveAt(e);
                        score += 10;
                        break;
                    }
                }
            }

            // Prohra
            foreach (var enemy in enemies)
            {
                if (enemy.y >= height - 3)
                    gameOver = true;
            }

            // Výhra – znovu vytvoří nepřátele
            if (enemies.Count == 0)
                InitEnemies();
        }

        void DrawGame()
        {
            Console.Clear();

            // Hráč
            Console.SetCursorPosition(playerX, height - 2);
            Console.Write("^");

            // Střely
            foreach (var b in bullets)
            {
                Console.SetCursorPosition(b.x, b.y);
                Console.Write("|");
            }

            // Nepřátelé
            foreach (var e in enemies)
            {
                Console.SetCursorPosition(e.x, e.y);
                Console.Write("W");
            }

            // Skóre
            Console.SetCursorPosition(1, 0);
            Console.Write($"Score: {score}");
        }
    }
}
