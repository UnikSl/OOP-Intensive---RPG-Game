namespace OOP_Intensive___RPG_Game
{
    public abstract class Hero
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int MaxHp { get; private set; }
        
        public Hero(string name, int hp, int strength, int agility)
        {
            Name = name;
            Hp = hp;
            MaxHp = hp;
            Strength = strength;
            Agility = agility;            

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

        public void GetHeal(int heal)
        {
            if (heal < 0)
            {
                heal = 0;  // Не стал выводить ошибку, тк в играх может быть так называемая проверка на успех и при провале можно получить нулевое лечение.
            }
            Hp += heal;
            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
        }
        public abstract int Attack(Monster monster);
        public abstract string ClassName { get; }
        //public abstract int GetHeal(Hero hero);
        

    }
}
