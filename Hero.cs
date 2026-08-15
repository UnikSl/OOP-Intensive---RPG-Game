namespace OOP_Intensive___RPG_Game
{
    public abstract class Hero
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int MaxHp { get; private set; }
        //public int Exp { get; private set; } = 0;
        public LevelProgress LevelProgress { get; private set; } = new LevelProgress();
        public List<Ability> Abilities { get; } = new List<Ability>();
        public bool IsAlive => Hp > 0;
        public int Health => Hp;
        
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

        public void Heal(int amount)
        {
            if (amount < 0)
            {
                amount = 0;  // Не стал выводить ошибку, тк в играх может быть так называемая проверка на успех и при провале можно получить нулевое лечение.
            }
            Hp += amount;
            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
        }
        public abstract int Attack(IEnemy enemy);
        public abstract string ClassName { get; }
        public virtual bool TryHeal()
        {
            return false;
        }
        public virtual bool TryDodge()
        {
            return false;
        }
        public virtual bool TryStun()
        {
            return false;
        }

        public void AddStars(int stars)
        {
            if (stars < 0)
            {
                throw new ArgumentException("Нельзя добавить отрицательное количество звезд");
            }
            Strength += stars;
            Agility += stars;
        }
        public void DisplayStats()
        {
            Console.WriteLine($"Герой {ClassName} по имени {Name} и у него {Hp} очкой здоровья");
            Console.WriteLine($"У него сила: {Strength}, ловкость: {Agility}");
            Console.WriteLine($"Уровень: {LevelProgress.Level}");
            Console.WriteLine();
        }
        public void RestoreHealth()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} восстанавливает здоровье до максимального значения!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Hp = MaxHp;
        }
        public bool TryUseAbility(IEnemy enemy)
        {
            foreach (var ability in Abilities)
            {
                if (ability.IsAvailable(this) && !ability.IsOnCooldown())
                {
                    ability.Use(this, enemy);
                    ability.StartCooldown();
                    return true;
                }
            }
            return false;
        }
        public void ReduceAbilityCooldowns()
        {
            foreach (var ability in Abilities)
            {
                ability.ReduceCooldown();
            }
        }
    }
}
