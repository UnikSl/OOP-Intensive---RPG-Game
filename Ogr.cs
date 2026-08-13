namespace OOP_Intensive___RPG_Game
{
    public class Ogr : Monster
    {        
            public Ogr(string name)
                : base(name, health: 120, armor: 15, strength: 20, agility: 8)
            {
            }

            public override string ClassName => "Огр";

            public override int Attack(Hero hero)
            {
                Random random = new Random();
                int damage = (Strength * 2) / (random.Next(1, Agility *2 ));
                hero.TakeDamage(damage);
                return damage;
            }
        
    }
}
