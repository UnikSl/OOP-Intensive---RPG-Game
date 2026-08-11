using OOP_Intensive___RPG_Game;

namespace RPGGAMEConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero("Рагнар", 100, 15, 5, 8);
            DisplayHeroStats(hero1);

            var goblin = new Monster("Гоблин", health: 30, armor: 3);
            Console.WriteLine($"Из темноты выходит {goblin.Name} (Здоровье: {goblin.Health}, Броня: {goblin.Armor})");
            var ogr = new Monster("Огр", health: 70, armor: 6);
            Console.WriteLine($"В компании {ogr.Name} (Здоровье: {ogr.Health}, Броня: {ogr.Armor})");
        }

        static void DisplayHeroStats(Hero hero)
        {
            if (hero.Hp > 0)
            {
                Console.WriteLine($"Герой {hero.Name} жив и у него {hero.Hp} очкой здоровья");
                Console.WriteLine($"У него сила: {hero.Strength}, ловкость: {hero.Agility} и очков опыта: {hero.Score}");
            }
            else 
            {
                Console.WriteLine($"Герой {hero.Name} покинул этот мир...");
            }
        }
    }
}