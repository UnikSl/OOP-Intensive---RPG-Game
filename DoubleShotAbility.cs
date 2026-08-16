namespace OOP_Intensive___RPG_Game
{
   
        public class DoubleShotAbility : Ability
        {
            public DoubleShotAbility() : base("Двойная стрела", 3, 3)
            {
            }

            public override void Use(Hero hero, IEnemy enemy)
            {
                Console.WriteLine($"{hero.Name} использует способность «{Name}»!");

                int damage = hero.Attack(enemy) * 2;

                if (!enemy.IsAlive)
                {
                    return;
                }

                Console.WriteLine($"{hero.Name} выпустил две стрелы и нанёс {damage} урона!");
            }
        }

}
