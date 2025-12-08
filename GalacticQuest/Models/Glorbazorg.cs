namespace GalacticQuest.Monsters
{
    public class Glorbazorg : Monster
    {
        public override string Name { get; set; } = "Glorbazorg";
        public override int Hp { get; set; } = 100;
        public override int Attack { get; set; } = 30;

        public override void BattleCry()
        {
            Console.WriteLine($"I AM {Name}! KNEEL BEFORE THE DAWN OF YOUR DEFEAT!");
        }

        public override void OnDeath()
        {
            Console.WriteLine("ROOOOAR");
        }
    }
}