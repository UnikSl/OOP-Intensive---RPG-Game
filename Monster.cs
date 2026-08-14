namespace OOP_Intensive___RPG_Game
{




    //public abstract class Monster
    //{
    //    public int _health;        
    //    public string Name { get; }
    //    public int Armor { get; }  // Броня уменьшает урон, который получает монстр
    //    public int Agility { get; }
    //    public int Strength { get; private set; }
    //    public int Health => _health;
    //    public bool IsAlive => _health > 0;
    //    public abstract string ClassName { get; }

    //    public Monster(string name, int health, int armor, int strength, int agility)
    //    {
    //        Name = name;
    //        _health = health;
    //        Armor = armor;
    //        Agility = agility;
    //        Strength = strength;
    //    }

    //    public void TakeDamage(int amount, bool ignoreArmor = false)
    //    {
    //        int real = ignoreArmor ? amount : amount - Armor;       // броня уменьшает урон
    //        if (real < 0)
    //            real = 0;

    //        _health -= real;

    //        if (_health < 0)
    //            _health = 0;
    //    }

    //    public abstract int Attack(Hero hero);
        
    //}
}