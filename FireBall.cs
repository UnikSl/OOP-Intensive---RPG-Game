namespace OOP_Intensive___RPG_Game
{
    public class FireBall : Ability
    {
        public FireBall() : base("Огненный шар", 3, 3)
        {
        }

        public override void Use(Hero hero, IEnemy enemy)
        {
            const int damage = 200;

            Console.WriteLine($"{hero.Name} запускает огненный шар в {enemy.Name} с уроном {damage}!");

            enemy.TakeDamage(damage);
            
        }
    }

}
