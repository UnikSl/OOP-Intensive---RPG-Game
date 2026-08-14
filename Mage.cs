namespace OOP_Intensive___RPG_Game
{
    public class Mage : Hero
    {
        public Mage(string name)
            : base(name, hp: 80, strength: 8, agility: 10)
        {
        }

        public override string ClassName => "Маг";

        public override int Attack(IEnemy enemy)
        {
            int damage = Strength * 3;
            enemy.TakeDamage(damage, ignoreArmor: true);
            return damage;
        }
    }
}