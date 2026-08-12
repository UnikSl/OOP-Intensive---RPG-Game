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

            var goblin = new Monster("Гоблин", health: 30, armor: 3);
            Console.WriteLine($"Из темноты выходит {goblin.Name} (Здоровье: {goblin.Health}, Броня: {goblin.Armor})");
            var ogr = new Monster("Огр", health: 70, armor: 6);
            Console.WriteLine($"В компании {ogr.Name} (Здоровье: {ogr.Health}, Броня: {ogr.Armor})");
                                
            if (hero is Acolyte acolyte)
            {
                acolyte.Heal();
            }
            DisplayHeroStats(hero);
            //while (true)
            //{
            //    Console.WriteLine("Нажмите Enter, чтобы атаковать Гоблина...");
            //    Console.ReadLine();

            //    int damage = hero.Attack(goblin);
            //    Console.WriteLine($"{hero.Name} наносит {damage} урона {goblin.Name}");

            //    if (!goblin.IsAlive)
            //    {
            //        Console.WriteLine($"{goblin.Name} повержен!");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{goblin.Name} (Здоровье: {goblin.Health}, Броня: {goblin.Armor})");
            //    }
            //}
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