namespace OOP_Intensive___RPG_Game
{
    class Battle
    {
        static Random random = new Random();
        public event Action<IEnemy> OnEnemyDefeated;
        public event Action<Hero> OnHeroDefeated;

        public void Fight(Hero hero, IEnemy enemy)
        {
            Console.WriteLine($"Битва начинается между {hero.Name} и {enemy.Name}!");

            while (enemy.IsAlive && hero.IsAlive)
            {
                int damageHero = hero.Attack(enemy);
                Console.WriteLine($"{hero.Name} наносит {damageHero} урона {enemy.Name}. (Здоровье у {enemy.Name} осталось {enemy.Health})");

                if (!enemy.IsAlive)
                {                    
                    OnEnemyDefeated?.Invoke(enemy);
                    break;
                }

                int damageEnemy = enemy.Attack(hero);
                Console.WriteLine($"{enemy.Name} наносит {damageEnemy} урона {hero.Name}");

                if (!hero.IsAlive)
                {
                    OnHeroDefeated?.Invoke(hero);
                    break;
                }
                else
                {
                    Console.WriteLine($"Здоровье у {hero.Name} осталось {hero.Health}");
                }
                if (hero.TryHeal())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{hero.Name} использует лечение!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}