namespace OOP_Intensive___RPG_Game
{
    public class Ogr : Enemy
    {
        private const int _armor = 10; // Броня уменьшает урон, который получает монстр
        private int _health = 80;
        public override string Name => "Огр";
        public override int Health => _health;
        public override int Armor => _armor;        
        public override int ExpReward => 35;
        public int Agility { get; private set; } = 5;
        public int Strength { get; private set; } = 15;
        public override void TakeDamage(int amount, bool ignoreArmor = false)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Нельзя наностить отрицательный урон");
            }
            int real = ignoreArmor ? amount - _armor / 2 : amount - _armor; // магия уменьшается от брони на 2
            _health -= Math.Max(real, 0);
            if (_health < 0)
            {
                _health = 0;
            }
        }

        protected override int CalculateDamage()
        {
            int damage = (Strength * 2) / (Random.Shared.Next(1, Agility * 2));
            return damage;
        }

    }
}
