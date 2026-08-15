namespace OOP_Intensive___RPG_Game
{
    public abstract class Enemy : IEnemy
    {
        public abstract string Name { get; }
        public abstract int Health { get; }
        public abstract int Armor { get; }
        public bool IsAlive => Health > 0;
        public abstract int ExpReward { get; }
        public abstract void TakeDamage(int amount, bool ignoreArmor = false);
        
        public int Attack(Hero hero)
        {
            if (hero.TryDodge())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{hero.Name} увернулся от атаки {Name}!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return 0;
            }

            int damage = CalculateDamage();
            hero.TakeDamage(damage);
            if (this is ILifeSteal lifeSteal)
            {
                lifeSteal.HealFromDamage(damage);
            }
            return damage;
        }

        protected abstract int CalculateDamage();
    }
}
