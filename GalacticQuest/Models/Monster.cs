namespace GalacticQuest.Monsters
{
    public abstract class Monster
    {
        public virtual string Name { get; set; } = "Unknown Monster";
        public virtual int Hp { get; set; } = 50;
        public virtual int Attack { get; set; } = 10;

        public Monster()
        {
            BattleCry();
        }

        public abstract void BattleCry();

        public virtual void OnDeath()
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
}