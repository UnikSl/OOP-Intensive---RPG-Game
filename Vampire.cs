
using static System.Net.Mime.MediaTypeNames;

namespace OOP_Intensive___RPG_Game
{


    internal partial class Program
    {
        public class Vampire : Enemy, ILifeSteal
        {
            private const int _armor = 3; // Броня уменьшает урон, который получает монстр
            private int _health = 50;                      
            
            public int Agility { get; private set; } = 10;
            public int Strength { get; private set; } = 5;

            public override string Name => "Вампир";

            public override int Health => _health;

            public override int Armor => _armor;

            public override int ExpReward => 45;
            public override void TakeDamage(int amount, bool ignoreArmor = false)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("Нельзя наностить отрицательный урон");
                }
                int real = ignoreArmor ? amount : amount - _armor;

                _health -= Math.Max(real, 0);
                if (_health < 0)
                {
                    _health = 0;
                }
            }
            
            protected override int CalculateDamage()
            {
                int damage = (Agility * 2) / (Random.Shared.Next(1, Strength * 2));
                return damage;
            }

            public int HealFromDamage(int damage)
            {
                int lifeStolen = damage / 2; // Ворует половину нанесенного урона
                _health += lifeStolen;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вампир похитил жизни " + lifeStolen);
                Console.ForegroundColor = ConsoleColor.Gray;

                return lifeStolen;
            }

            

            
        }
    }
}