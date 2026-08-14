namespace OOP_Intensive___RPG_Game
{
    public class Acolyte : Hero
    {
        private Random random = new Random();
        public Acolyte(string name)
            : base(name, hp: 60, strength: 15, agility: 8)
        {
        }

        public override string ClassName => "Аколит";

        public override int Attack(IEnemy enemy)
        {
            int damage = (Strength + Agility)/ 4;
            enemy.TakeDamage(damage);
            return damage;
        }
        
        public void Heal()
        {
            int giveHeal = Strength + Agility;
            Heal(giveHeal);           
        }
        public override bool TryHeal()
        {
            if (Health >= MaxHp / 2)
            {
                return false;
            }

            if (random.Next(100) >= 70)
            {
                return false;
            }

            Heal();

            return true;
        }
    }
}