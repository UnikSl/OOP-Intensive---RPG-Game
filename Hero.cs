namespace OOP_Intensive___RPG_Game
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Score { get; private set; }

        public Hero(string name, int hp, int strength, int agility, int score)
        {
            Name = name;
            Hp = hp;
            Strength = strength;
            Agility = agility;
            Score = score;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Нельзя наностить отрицательный урон");
            }
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }
        }

        public void Heal(int heal)
        {
            if (heal < 0)
            {
                heal = 0;  // Не стал выводить ошибку, тк в играх может быть так называемая проверка на успех и при провале можно получить нулевое лечение.
            }
            Hp += heal;
            if (Hp > 100)
            {
                Hp = 100;
            }
        }

    }
}
