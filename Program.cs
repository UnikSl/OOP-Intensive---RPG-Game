namespace OOP_Intensive___RPG_Game
{

    internal class Program
    {
        static Random random = new Random();
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

            var goblin = new Monster("Гоблин", health: 30, armor: 3);
            Console.WriteLine($"Из темноты выходит {goblin.Name} (Здоровье: {goblin.Health}, Броня: {goblin.Armor})");
            var ogr = new Monster("Огр", health: 70, armor: 6);
            Console.WriteLine($"В компании {ogr.Name} (Здоровье: {ogr.Health}, Броня: {ogr.Armor})");
            
            while (hero.Hp > 0 && goblin.Health > 0)
            {
                Console.WriteLine("Нажмите Enter, чтобы атаковать Гоблина...");
                Console.ReadLine();

                int damageHero = hero.Attack(goblin);
                Console.WriteLine($"{hero.Name} наносит {damageHero} урона {goblin.Name}");                              

                if (!goblin.IsAlive)
                {
                    Console.WriteLine($"{goblin.Name} повержен!");
                    Console.WriteLine($"Победил в схватке {hero.Name}");
                    break;
                }
                else
                {
                    Console.WriteLine($"{goblin.Name} (Здоровье: {goblin.Health}, Броня: {goblin.Armor})");
                }

                Console.WriteLine("Атакует Гоблин. Нажмите Enter...");
                Console.ReadLine();

                int damageMonster = goblin.Attack(hero);
                Console.WriteLine($"{goblin.Name} наносит {damageMonster} урона {hero.Name}");

                if (!hero.IsAlive)
                {
                    Console.WriteLine($"{hero.Name} повержен!");
                    Console.WriteLine($"Победил в схватке {goblin.Name}");
                    break;
                }
                else
                {
                    Console.WriteLine($"{hero.Name} (Здоровье: {hero.Health})");
                }
                if (hero.Health < hero.MaxHp / 2 && hero is Acolyte acolyte)
                {
                    if (random.Next(100) < 30)
                    {
                        acolyte.Heal();
                        Console.WriteLine($"{hero.Name} использует лечение!");
                    }
                }
                DisplayHeroStats(hero);
            }
            Console.ReadLine();
        }

        static void DisplayHeroStats(Hero hero)
        {
            if (hero.Hp > 0)
            {
                Console.WriteLine($"Герой {hero.ClassName} по имени {hero.Name} жив и у него {hero.Hp} очкой здоровья");
                Console.WriteLine($"У него сила: {hero.Strength}, ловкость: {hero.Agility}");
            }
            else 
            {
                Console.WriteLine($"Герой {hero.ClassName} по имени {hero.Name} покинул этот мир...");
            }
        }
    }
}