namespace OOP_Intensive___RPG_Game
{
    public class Archer : Hero
    {
        public Archer(string name)
            : base(name, hp: 90, strength: 10, agility: 15)
        {
        }

        public override string ClassName => "Лучник";


        public override int Attack(IEnemy enemy)
        {
            int damage = Strength / 2 + Agility;

            // 25% шанс нанести критический удар, удваивающий урон
            Random random = new Random();
            if (random.Next(100) < 25)
            {
                damage *= 2;
            }//

            enemy.TakeDamage(damage);
            return damage;
        }
    }
}