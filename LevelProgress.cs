namespace OOP_Intensive___RPG_Game
{
    public class LevelProgress
    {
        public int Level { get; private set; } = 1;
        public int Exp { get; private set; } = 0;
        public int ExpToNextLevel => Level * 50;
        public bool AddExp(int exp)
        {
            Exp += exp;
            bool leveledUp = false;

            while (Exp >= ExpToNextLevel)
            {
                Exp -= ExpToNextLevel;
                Level++;                
                leveledUp = true;
            }
            return leveledUp;
        }

    }
}