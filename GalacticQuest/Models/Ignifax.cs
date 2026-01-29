namespace GalacticQuest.Monsters
{
    public class Ignifax : Monster
    {
        public Ignifax(string name, int hp, int attack) : base(name, hp, attack)
        {
            BattleCry();
            SpecialAction = () => PerformSpecialAction();
        }

        public override void BattleCry()
        {
            Console.WriteLine($"BURN TO CINDERS! {Name} HAS ARRIVED TO CONSUME THE LIGHT");
        }
        public void PerformSpecialAction()
        {
            Hp += 2;
            Attack /= 2;
            Console.WriteLine($"{Name} uses its special ability to regenerate its flames, increasing its HP to {Hp} but reducing its attack power to {Attack}.");
        }

        public override void OnDeath()
        {
            Console.WriteLine("YOU DOUSE ONE SPARK... BUT THE FIRE OF DESTRUCTION IS ETERNAL! I AM ONLY THE BEGINNING OF YOUR ASH!");
        }
    }
}