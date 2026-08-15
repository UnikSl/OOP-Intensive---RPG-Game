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

                int damage1 = hero.Attack(enemy);

                if (!enemy.IsAlive)
                {
                    return;
                }

                int damage2 = hero.Attack(enemy);

                Console.WriteLine($"{hero.Name} выпустил две стрелы и нанёс {damage1 + damage2} урона!");
            }
        }

}
