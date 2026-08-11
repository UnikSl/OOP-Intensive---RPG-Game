namespace RPGGAMEConsoleApp
{
    public class Monster
    {
        private int _health;

        public string Name { get; }
        public int Armor { get; }

        public int Health => _health;
        public bool IsAlive => _health > 0;

        public Monster(string name, int health, int armor)
        {
            Name = name;
            _health = health;
            Armor = armor;
        }

        public void TakeDamage(int amount)
        {
            int real = amount - Armor;       // броня уменьшает урон
            if (real < 0)
                real = 0;

            _health -= real;

            if (_health < 0)
                _health = 0;
        }
    }
}