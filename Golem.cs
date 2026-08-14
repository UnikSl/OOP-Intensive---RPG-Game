namespace OOP_Intensive___RPG_Game
{
    public class Golem : IEnemy
    {
        private const int _armor = 15; // Броня уменьшает урон, который получает монстр
        private int _health = 100;

        public string Name => "Голем";

        public int Health => _health;

        public bool IsAlive => _health > 0;
        public int Armor => _armor;
        public int ExpReward => 50;
        public int Agility { get; private set; } = 3;
        public int Strength { get; private set; } = 20;

        public void TakeDamage(int amount, bool ignoreArmor = false)
        {
            int real = ignoreArmor ? amount : amount - _armor;

            _health -= Math.Max(real, 0);
            if (_health < 0)
            {
                _health = 0;
            }
        }

        public int Attack(Hero hero)
        {
            Random random = new Random();
            int damage = (Strength + random.Next(1, Strength / 2)) / (random.Next(1, Agility * 2));
            hero.TakeDamage(damage);
            return damage;
        }

    }

}
