namespace OOP_Intensive___RPG_Game
{
    public class Acolyte : Hero
    {
        public Acolyte(string name)
            : base(name, hp: 60, strength: 15, agility: 8)
        {
        }

        public override string ClassName => "Аколит";

        public override int Attack(Monster monster)
        {
            int damage = (Strength + Agility)/ 4;
            monster.TakeDamage(damage);
            return damage;
        }
        
        public void Heal()
        {
            int giveHeal = Strength + Agility;
            base.GetHeal(giveHeal);           
        }
    }
}