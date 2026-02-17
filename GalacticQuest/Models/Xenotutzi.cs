namespace GalacticQuest.Monsters
{
    public class Xenotutzi : Monster
    {
        public Xenotutzi(string name, int hp, int attack) : base(name, hp, attack)
        {
            BattleCry();
            SpecialAttack = () => PerformSpecialAttack();
        }

        public override void BattleCry()
        {
            Console.WriteLine($"THE VOID SINGS MY NAME! {Name} CLAIMS THIS WORLD");
        }

        private void PerformSpecialAttack()
        {
            this.Attack *= 2;
            this.Hp /= 2;
            Console.WriteLine("6-7; 6-7");
        }
    }
}
