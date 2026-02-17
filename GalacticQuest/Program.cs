using GalacticQuest.Items;
using GalacticQuest.Monsters;
using GalacticQuest.Planets;

namespace GalacticQuest
{
    internal class Program
    {
        internal static Player currentPlayer = new Player(100, 10, 250);
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, Galactic Quest!");

            IList<Monster> monsters = new List<Monster>() { new Xenotutzi("monstrulet", 100, 20), new Ignifax("MONSTRU", 30, 30) };
            foreach (var monster in monsters)
            {
                monster.SpecialAttack();
                Console.WriteLine($"Hp: {monster.Hp} | Attack: {monster.Attack}");
            }

            //OpenMainMenu();
        }

        internal static void OpenMainMenu()
        {
            bool stillInRun = true;

            while (stillInRun)
            {
                Console.Write("\n");
                Console.WriteLine("Select your option and press Enter: \n 1.Travel \n 2.Journal \n 3.Backpack \n 4.Finish Run \n");
                int.TryParse(Console.ReadLine(), out int readOption);

                try
                {
                    switch (readOption)
                    {
                        case 1:
                            OpenTravelMenu();
                            break;

                        case 2:
                            OpenJournalMenu();
                            break;

                        case 3:
                            OpenBackpackMenu();
                            break;

                        case 4:
                            stillInRun = false;
                            break;

                        default:
                            throw new Exception("Invalid Option");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("(-_-') " + ex.Message);
                    stillInRun = false;
                }
            }
        }

        internal static void OpenTravelMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Explore \n 2.Search For Items \n 3.Back To Ship \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    Console.WriteLine("Selected Explore");
                    PlanetHelper.TravelToRandomPlanet();
                    break;

                case 2:
                    Console.WriteLine("Selected Search For Items");
                    PlanetHelper.SearchForItems();
                    break;

                case 3:
                    Console.WriteLine("Selected Back To Ship");
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;

            }
        }

        internal static void OpenBackpackMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Displaying the Backpack menu\n");

            Console.WriteLine("Select your option and press Enter: \n 1.Show current items in backpack.\n 2.Add a basic DoomFist to backpack\n 3.Back to Main Menu\n");

            int.TryParse(Console.ReadLine(), out int userOption);

            switch (userOption)
            {
                case 1:
                    currentPlayer.ShowItemsInBackpack();
                    break;

                case 2:
                    Item basicItem = new DoomFist("Basic doomfist", 100, 20);
                    currentPlayer.AddItemToBackpack(basicItem);
                    break;

                case 3:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static void OpenJournalMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Monsters \n 2.Planets \n 3.Items \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    CreateAndDisplayMonsters();
                    break;

                case 2:
                    Console.WriteLine("Selected Planets");
                    break;

                case 3:
                    Console.WriteLine("Selected Items");
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static void CreateAndDisplayMonsters()
        {
            Console.Write("\n");
            Console.WriteLine("Displaying Created Monsters:");

            Random randomGenerator = new Random();
            IList<Monster> monsters = new List<Monster>()
            {
                new Glorbazorg("Glorbazorg", randomGenerator.Next(10, 100), randomGenerator.Next(10, 100)),
                new Xenotutzi("Xenotutzi", randomGenerator.Next(10, 100), randomGenerator.Next(10, 100)),
                new Kryostasis("Kryostasis", randomGenerator.Next(10, 100), randomGenerator.Next(10, 100)),
                new Ignifax("Ignifax", randomGenerator.Next(10, 100), randomGenerator.Next(10, 100))
            };

            ShowMonsters(monsters);
        }

        internal static void ShowMonsters(IList<Monster> monsters)
        {
            Console.Write("\n");
            Console.WriteLine("The monsters are : ");

            foreach (Monster monster in monsters)
            {
                Console.WriteLine(monster.Name + " - " + monster.Hp + " HP | " + monster.Attack + " Attack");
            }
            Console.Write("\n");

            ShowMonstersOptions(monsters);
        }

        internal static void ShowMonstersOptions(IList<Monster> monsters)
        {
            Console.WriteLine("Select your option and press Enter: \n 1.Go Back \n 2.Filter Monsters By Name \n 3.Show Monsters Last Words\n");

            int.TryParse(Console.ReadLine(), out int userOption);
            switch (userOption)
            {
                case 1:
                    break;

                case 2:
                    FilterMonstersByName(monsters);
                    break;

                case 3:
                    ShowMonstersLastWords(monsters);
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static void FilterMonstersByName(IList<Monster> monsters)
        {
            Console.WriteLine("Enter letters to filter monsters: ");
            string? userInput = Console.ReadLine();

            Console.Write("\n");

            Dictionary<string, int> filteredMonstersByName = new Dictionary<string, int>();
            if (!string.IsNullOrEmpty(userInput))
            {
                string lowerCasedUserInput = userInput.ToLower();
                foreach (Monster monster in monsters)
                {
                    string currentMonsterName = monster.Name;
                    string lowerCasedCurrentMonster = currentMonsterName.ToLower();

                    if (lowerCasedCurrentMonster.StartsWith(lowerCasedUserInput))
                    {
                        int currentMonsterHp = monster.Hp;
                        filteredMonstersByName.Add(currentMonsterName, currentMonsterHp);
                    }
                }
            }
            else
            {
                Console.WriteLine("No input provided. Showing all monsters.");
                Console.Write("\n");

                foreach (Monster monster in monsters)
                {
                    Console.WriteLine(monster.Name);
                }
            }

            if (filteredMonstersByName.Count == 0)
            {
                Console.WriteLine("None of the monsters starts with these letters.");
                Console.Write("\n");
            }
            else
            {
                foreach (var filteredMonster in filteredMonstersByName)
                {
                    Console.WriteLine(filteredMonster.Key + " - " + filteredMonster.Value + " HP");
                }
            }
        }

        internal static void ShowMonstersLastWords(IList<Monster> monsters)
        {
            Console.WriteLine("Monsters' Last Words:");

            foreach (Monster monster in monsters)
            {
                monster.OnDeath();
            }
        }
    }
}