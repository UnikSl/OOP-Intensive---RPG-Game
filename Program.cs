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

            Console.WriteLine("Из темноты лесной чащи выходит: ");
            Console.WriteLine("Выберите врага для героя:");
            Console.WriteLine("1. Гоблин");
            Console.WriteLine("2. Огр");
            var choiceMonster = Console.ReadLine();
            Monster monster = null;
            switch (choiceMonster)
            {
                case "1":
                    monster = new Goblin("Гоблин");
                    break;
                case "2":
                    monster = new Ogr("Огр");
                    break;                
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }
                      
            Console.WriteLine($"Из темноты выходит {monster.Name} (Здоровье: {monster.Health}, Броня: {monster.Armor})"); 
            
            while (hero.Hp > 0 && monster.Health > 0)
            {
                Console.WriteLine("Нажмите Enter, чтобы атаковать Гоблина...");
                Console.ReadLine();

                int damageHero = hero.Attack(monster);
                Console.WriteLine($"{hero.Name} наносит {damageHero} урона {monster.Name}");                              

                if (!monster.IsAlive)
                {
                    Console.WriteLine($"{monster.Name} повержен!");
                    Console.WriteLine($"Победил в схватке {hero.Name}");
                    break;
                }
                else
                {
                    Console.WriteLine($"{monster.Name} (Здоровье: {monster.Health}, Броня: {monster.Armor})");
                }

                Console.WriteLine($"Атакует {monster.Name}. Нажмите Enter...");
                Console.ReadLine();

                int damageMonster = monster.Attack(hero);
                Console.WriteLine($"{monster.Name} наносит {damageMonster} урона {hero.Name}");

                if (!hero.IsAlive)
                {
                    Console.WriteLine($"{hero.Name} повержен!");
                    Console.WriteLine($"Победил в схватке {monster.Name}");
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
                
            }
            Console.ReadLine();
        }

        static void DisplayHeroStats(Hero hero)
        {
            if (hero.Hp > 0)
            {
                Console.WriteLine($"Герой {hero.ClassName} по имени {hero.Name} и у него {hero.Hp} очкой здоровья");
                Console.WriteLine($"У него сила: {hero.Strength}, ловкость: {hero.Agility}");
            }
            else 
            {
                Console.WriteLine($"Герой {hero.ClassName} по имени {hero.Name} покинул этот мир...");
            }
        }
    }
}