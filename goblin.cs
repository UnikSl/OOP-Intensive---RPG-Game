namespace OOP_Intensive___RPG_Game
{
    public class Goblin : Enemy
    {
        private const int _armor = 3; // Броня уменьшает урон, который получает монстр
        private int _health = 30;
        
        public override string Name => "Гоблин";

        public override int Health => _health;

        public override int Armor => _armor;
        public override int ExpReward => 20;
        public int Agility { get; private set; } = 10;
        public int Strength { get; private set; } = 5;
        public override void TakeDamage(int amount, bool ignoreArmor = false)
        {
            int real = ignoreArmor ? amount : amount - _armor;
                         
            _health -= Math.Max(real, 0);
            if (_health < 0)
            {
                _health = 0;
            }
        }

        protected override int CalculateDamage()
        {
            Random random = new Random();
            int damage = (Agility * 2) / (random.Next(1, Strength * 2));
            return damage;
        }        

    }

}
