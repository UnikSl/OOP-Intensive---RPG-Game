namespace OOP_Intensive___RPG_Game
{
    public class Warrior : Hero
    {
        public Warrior(string name)
            : base(name, hp: 120, strength: 15, agility: 8)
        {
        }

        public override string ClassName => "Воин";

        public override int Attack(IEnemy enemy)
        {
            int damage = Strength * 2;
            enemy.TakeDamage(damage);
            return damage;
        }
    }
}