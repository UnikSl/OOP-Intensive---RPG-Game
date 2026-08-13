namespace OOP_Intensive___RPG_Game
{
    public class Goblin : Monster
    {
        public Goblin(string name)
            : base(name, health: 80, armor: 0, strength: 8, agility: 15)
        {
        }

        public override string ClassName => "Гоблин";

        public override int Attack(Hero hero)
        {
            Random random = new Random();
            int damage = (Agility * 2) / (random.Next(1, Strength * 2));
            hero.TakeDamage(damage);
            return damage;
        }

    }
}