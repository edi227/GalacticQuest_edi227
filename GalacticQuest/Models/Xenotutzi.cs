namespace GalacticQuest.Monsters
{
    public class Xenotutzi : Monster
    {
        public override string Name { get; set; } = "Xenotutzi ";
        public override int Hp { get; set; } = 140;
        public override int Attack { get; set; } = 15;

        public override void BattleCry()
        {
            Console.WriteLine($"THE VOID SINGS MY NAME! {Name} CLAIMS THIS WORLD");
        }
    }
}