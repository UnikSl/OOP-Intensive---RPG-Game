namespace OOP_Intensive___RPG_Game
{
    public class Ogr : IEnemy
    {
        private const int _armor = 10; // Броня уменьшает урон, который получает монстр
        private int _health = 80;
        public string Name => "Огр";
        public int Health => _health;
        public int Armor => _armor;
        public bool IsAlive => _health > 0;
        public int ExpReward => 35;
        public int Agility { get; private set; } = 5;
        public int Strength { get; private set; } = 15;
        public void TakeDamage(int amount, bool ignoreArmor = false)
        {
            int real = ignoreArmor ? amount - _armor / 2 : amount - _armor; // магия уменьшается от брони на 2
            _health -= Math.Max(real, 0);
            if (_health < 0)
            {
                _health = 0;
            }
        }
        public int Attack(Hero hero)
        {
            Random random = new Random();
            int damage = (Strength * 2) / (random.Next(1, Agility * 2));
            hero.TakeDamage(damage);
            return damage;
        }

    }
}
