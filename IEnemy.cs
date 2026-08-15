namespace OOP_Intensive___RPG_Game
{
    public interface IEnemy
    {
        string Name { get; }
        int Health { get; }
        int Armor { get; }  
        bool IsAlive { get; }
        int ExpReward { get; } //Опыт за победу над врагом
        void TakeDamage(int amount, bool ignoreArmor = false);
        int Attack(Hero hero);
    }
}
