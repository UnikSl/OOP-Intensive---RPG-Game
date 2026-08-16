using System.Diagnostics;

namespace OOP_Intensive___RPG_Game
{
    internal class Game
    {
        //public Game()
        //{
        //}

        internal int Play()
        {
            Console.Write("\n=== ЛОВИ Звезды 10 СЕКУНД ===");

            int stars = 0;            
            var watch = Stopwatch.StartNew();
            bool visible = false;
            var nextStarTime = TimeSpan.Zero;

            while (watch.Elapsed.TotalSeconds < 10)
            {
                if (!visible && watch.Elapsed >= nextStarTime)
                {
                    Console.WriteLine("🌟 ");
                    visible = true;
                }
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                    if (visible)
                    {
                        stars++;
                        visible = false;                       
                        nextStarTime = watch.Elapsed + TimeSpan.FromMilliseconds(Random.Shared.Next(500, 1500));
                    }
                }
                
            }

            watch.Stop();
            Console.WriteLine($"Время вышло! Всего звезд: {stars}");
            return stars;
        }
    }
}