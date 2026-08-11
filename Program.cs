namespace RPGGAMEConsoleApp
{

    public class Monster
    {
        
    }
    class Hero
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Score { get; private set; }

        public Hero(string name, int hp, int strength, int agility,int score)
        {
            Name = name;
            Hp = hp;
            Strength = strength;
            Agility = agility;
            Score = score;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Нельзя наностить отрицательный урон");
            }
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero("Рагнар", 100, 15, 5, 8);           

            DisplayHeroStats(hero1);
            hero1.TakeDamage(20);
        }

        static void DisplayHeroStats(Hero hero)
        {
            Console.WriteLine($"Имя героя: {hero.Name}");
            Console.WriteLine($"Здоровье: {hero.Hp}");
            Console.WriteLine($"Сила: {hero.Strength}");
            Console.WriteLine($"Ловкость: {hero.Agility}");
            Console.WriteLine($"Счет: {hero.Score}");

        }
    }
}