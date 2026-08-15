namespace OOP_Intensive___RPG_Game
{
    public abstract class Ability
    {
        public string Name { get; private set; }
        public int RequiredLevel { get; private set; }
        public int Cooldown { get; private set; }
        public int CurrentCooldown { get; private set; }

        protected Ability(string name, int requiredLevel, int cooldown)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Cooldown = cooldown;
            CurrentCooldown = 0;
        }

        public bool IsAvailable(Hero hero)
        {
            return hero.LevelProgress.Level >= RequiredLevel;
        }
        public bool IsOnCooldown()
        {
            return CurrentCooldown > 0;
        }
        public void StartCooldown()
        {
            CurrentCooldown = Cooldown;
        }
        public void ReduceCooldown()
        {
            if (CurrentCooldown > 0)
            {
                CurrentCooldown--;
            }
        }
        public void ResetCooldown()
        {
            CurrentCooldown = 0;
        }
        public abstract void Use(Hero hero, IEnemy enemy);
    }

    
}
