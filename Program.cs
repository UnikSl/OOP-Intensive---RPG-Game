namespace OOP_Intensive___RPG_Game
{


    internal class Program
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
            
            DisplayHeroStats(hero);

            IEnemy[] enemies = new IEnemy[]
            {
                new Goblin(),
                new Ogr(),
                new Golem(),
            };

            var battle = new Battle();
            var totalExp = 0;   
            var killedEnemies = new List<IEnemy>();            
            battle.OnEnemyDefeated += (enemy) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{enemy.Name} повержен!");
                totalExp += enemy.ExpReward;
                Console.WriteLine($"Победил в схватке {hero.Name} и получил {enemy.ExpReward} опыта.");
                Console.ForegroundColor = ConsoleColor.Gray;
            };
            
            battle.OnEnemyDefeated += (enemy) =>
            {
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

            foreach (var enemy in enemies)
            {
                if (!hero.IsAlive)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Из темноты лесной чащи выходит {enemy.Name} (Здоровье: {enemy.Health}, Броня: {enemy.Armor})");
                Console.ForegroundColor = ConsoleColor.Gray;
                battle.Fight(hero, enemy);
            }
            if (killedEnemies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{hero.Name} победил следующих врагов:");
                foreach (var enemy in killedEnemies)
                {
                    Console.WriteLine($"{enemy.Name}");
                }
                Console.WriteLine($"Опыт который смог заработать {hero.Name} за победу над {killedEnemies.Count} {GetEnemyWord(killedEnemies.Count)}: {totalExp}");
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

        static void DisplayHeroStats(Hero hero)
        {            
            Console.WriteLine($"Герой {hero.ClassName} по имени {hero.Name} и у него {hero.Hp} очкой здоровья");
            Console.WriteLine($"У него сила: {hero.Strength}, ловкость: {hero.Agility}");            
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
    }
}