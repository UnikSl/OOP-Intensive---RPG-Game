namespace OOP_Intensive___RPG_Game
{
    internal partial class Program
    {        
        static void Main(string[] args)
        {

            Console.Write("Введите имя героя: ");
            var name = Console.ReadLine();

            Console.WriteLine("Выберите класс героя:");
            Console.WriteLine("1. Воин");
            Console.WriteLine("2. Маг");
            Console.WriteLine("3. Лучник");
            Console.WriteLine("4. Аколит");
            var choice = Console.ReadLine();

            Hero hero = null;
            switch (choice)
            {
                case "1":
                    hero = new Warrior(name);
                    break;
                case "2":
                    hero = new Mage(name);
                    break;
                case "3":
                    hero = new Archer(name);
                    break;
                case "4":
                    hero = new Acolyte(name);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }
            
            hero.DisplayStats();

            var battle = new Battle();
              
            var killedEnemies = new List<IEnemy>();            
            battle.OnEnemyDefeated += (enemy) =>
            {
                var leveledUp = hero.LevelProgress.AddExp(enemy.ExpReward);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{enemy.Name} повержен!");                
                Console.WriteLine($"Победил в схватке {hero.Name} и получил {enemy.ExpReward} опыта.");
                if (leveledUp)
                {
                    Console.WriteLine($"{hero.Name} достиг уровня {hero.LevelProgress.Level}!");
                    hero.RestoreHealth();
                    hero.DisplayStats();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            };
            
            battle.OnEnemyDefeated += (enemy) =>
            {
                hero.ReduceAbilityCooldowns();
                killedEnemies.Add(enemy);                                
            };

            battle.OnHeroDefeated += (hero) =>
            {                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"===== ПОТРАЧЕНО =====");
                Console.WriteLine();
                Console.WriteLine($"{hero.Name} покинул этот мир...");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                
            };

            var game = new Game();



            while (hero.IsAlive && killedEnemies.Count < 20)  // Сражения идут до тех пор пока жив герой или он не победит ХХ врагов
            {
                IEnemy enemy = CreateRandomEnemy();

                if (!hero.IsAlive)
                {
                    break;
                }                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Из темноты лесной чащи выходит {enemy.Name} (Здоровье: {enemy.Health}, Броня: {enemy.Armor})");
                Console.ForegroundColor = ConsoleColor.Gray;
                battle.Fight(hero, enemy);
                
                if (hero.IsAlive)
                {    
                    var stars = game.Play();
                    hero.AddStars(stars);
                    Console.WriteLine($" {hero.Name} увеличил свои характеристики на {stars}.");
                }
                hero.DisplayStats();
            }
            if (killedEnemies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{hero.Name} победил следующих врагов:");
                foreach (var enemy in killedEnemies)
                {
                    Console.WriteLine($"{enemy.Name}");
                }
                Console.WriteLine($"Герой {hero.Name} победил {killedEnemies.Count} {GetEnemyWord(killedEnemies.Count)} и повысил свой уровень до {hero.LevelProgress.Level}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{hero.Name} не смог победить ни одного врага...");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
            Console.ReadLine();
        }

        static string GetEnemyWord(int count)
        {
            if (count % 100 >= 11 && count % 100 <= 14)
            {
                return "врагов";
            }

            switch (count % 10)
            {
                case 1:
                    return "врагом";
                case 2:
                case 3:
                case 4:
                    return "врагами";
                default:
                    return "врагов";
            }
        }

       static IEnemy CreateRandomEnemy()
        {
            Random random = new Random();
            int choice = random.Next(4);

            switch (choice)
            {
                case 1:
                    return new Goblin();
                case 2:
                    return new Ogr();
                case 3:
                    return new Golem();                
                default:
                    return new Vampire();
            }
        }

    }
}