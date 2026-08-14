namespace OOP_Intensive___RPG_Game
{
    public interface IEnemy
    {
        string Name { get; }
        int Health { get; }
        int Armor { get; }  
        bool IsAlive { get; }
        int ExpReward { get; } //experience reward for killing the enemy
        void TakeDamage(int amount, bool ignoreArmor = false);
        int Attack(Hero hero);
    }
}
