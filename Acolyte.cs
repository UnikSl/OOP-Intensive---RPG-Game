namespace OOP_Intensive___RPG_Game
{
    public class Acolyte : Hero
    {
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
    }
}