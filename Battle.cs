namespace OOP_Intensive___RPG_Game
{
    public class Battle
    {        
        public event Action<IEnemy> OnEnemyDefeated;
        public event Action<Hero> OnHeroDefeated;

        public void Fight(Hero hero, IEnemy enemy)
        {
            Console.WriteLine($"Битва начинается между {hero.Name} и {enemy.Name}!");

            while (enemy.IsAlive && hero.IsAlive)
            {
                if (!hero.TryUseAbility(enemy))
                {
                    int damageHero = hero.Attack(enemy);
                    Console.WriteLine($"{hero.Name} наносит {damageHero} урона {enemy.Name}.(Здоровье у {enemy.Name} осталось {enemy.Health})");

                }
                
                if (!enemy.IsAlive)
                {                    
                    OnEnemyDefeated?.Invoke(enemy);
                    break;
                }
                
                if (hero.TryStun())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{hero.Name} оглушает {enemy.Name}!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue; // Враг пропускает ход, если он оглушен
                }                             

                int damageEnemy = enemy.Attack(hero);
                Console.WriteLine($"{enemy.Name} наносит {damageEnemy} урона {hero.Name}");

                hero.ReduceAbilityCooldowns();

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