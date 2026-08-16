namespace OOP_Intensive___RPG_Game
{
    public class Golem : Enemy
    {
        private const int _armor = 15; // Броня уменьшает урон, который получает монстр
        private int _health = 100;

        public override string Name => "Голем";

        public override int Health => _health;

        public override int Armor => _armor;
        public override int ExpReward => 50;

        public int Agility { get; private set; } = 3;
        public int Strength { get; private set; } = 20;

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
            int damage = (Strength + Random.Shared.Next(1, Strength / 2)) / (Random.Shared.Next(1, Agility * 2));
            return damage;
        }        

    }

}
