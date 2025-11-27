namespace GalacticQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Galactic Quest!");

            OpenMainMenu();
        }

        internal static void OpenMainMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Select your option and press Enter: \n 1.Travel \n 2.Journal \n 3.Exit \n");
                int.TryParse(Console.ReadLine(), out int readOption);


                switch (readOption)
                {
                    case (int)GameOptions.Monsters:
                        OpenTravelMenu();
                        break;

                    case (int)GameOptions.Journal:
                        OpenJournalMenu();
                        break;

                    case (int)GameOptions.Exit:
                        isAppRunning = false;
                        break;

                    default:
                        Console.WriteLine("-_-' Invalid Option");
                        break;

                }
            }
        }

        internal enum GameOptions
        {
            Monsters = 1,
            Journal = 2,
            Exit = 3
        }

        internal static void OpenTravelMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Explore \n 2.Search For Items \n 3.Back To Ship \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    Console.WriteLine("Selected Explore");
                    break;

                case 2:
                    Console.WriteLine("Selected Search For Items");
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

        internal static void OpenJournalMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Monsters \n 2.Planets \n 3.Items \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    List<string> monstersWithNames = CreateMonstersWithNames();
                    Dictionary<string, int> monstersWithHp = CreateMonstersWith("hp", monstersWithNames);
                    Dictionary<string, int> monstersWithAttack = CreateMonstersWith("attack", monstersWithNames);
                    ShowMonsters(monstersWithHp, monstersWithAttack);
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

        internal static List<string> CreateMonstersWithNames()
        {
            List<string> monstersList = new List<string>
            {
                "Glorbazorg",
                "Xenotutzi",
                "Ignifax",
                "Kryostasis",
                "Nighthorn",
                "Leviathan-Maw",
                "Hydro-King Aqueron",
                "Stonemouth"
            };
            return monstersList;
        }

        internal static Dictionary<string, int> CreateMonstersWith(string hpOrAttack, List<string> monstersList)
        {
            Dictionary<string, int> monstersDictionary = new Dictionary<string, int>();
            Random randomGenerator = new Random();

            for (int i = 0; i < monstersList.Count; ++i)
            {
                string monsterKey = monstersList[i];
                int monsterValue = 0; // default value

                if (hpOrAttack == "hp")
                {
                    monsterValue = randomGenerator.Next(10, 100);
                }
                else if (hpOrAttack == "attack")
                {
                    monsterValue = randomGenerator.Next(1, 20);
                }

                monstersDictionary.Add(monsterKey, monsterValue);
            }

            return monstersDictionary;
        }

        internal static void ShowMonsters(Dictionary<string, int> monstersWithHp, Dictionary<string, int> monstersWithAttack)
        {
            Console.WriteLine("The monsters are : ");

            for (int index = 0; index < monstersWithHp.Count; ++index)
            {
                Console.WriteLine(monstersWithHp.Keys.ElementAt(index) + " - " + monstersWithHp.Values.ElementAt(index) + " HP");
            }
            Console.WriteLine("\n");

            for (int index = 0; index < monstersWithAttack.Count; ++index)
            {
                Console.WriteLine(monstersWithAttack.Keys.ElementAt(index) + " - " + monstersWithAttack.Values.ElementAt(index) + " ATT");
            }
            Console.WriteLine("\n");

            ShowMonstersOptions(monstersWithHp);
        }

        internal static void ShowMonstersOptions(Dictionary<string, int> monstersWithHp)
        {
            Console.WriteLine("Press 1 to go back or 2 to filter monsters based on name");

            int.TryParse(Console.ReadLine(), out int userOption);
            switch (userOption)
            {
                case 1:
                    break;

                case 2:
                    FilterMonstersByName(monstersWithHp);
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static void FilterMonstersByName(Dictionary<string, int> monstersWithHp)
        {
            Console.WriteLine("Enter letters to filter monsters: ");
            string? userInput = Console.ReadLine();

            Console.WriteLine("\n");

            Dictionary<string, int> filteredMonstersByName = new Dictionary<string, int>();
            if (!string.IsNullOrEmpty(userInput))
            {
                string lowerCasedUserInput = userInput.ToLower();
                for (int index = 0; index < monstersWithHp.Count; ++index)
                {
                    string currentMonsterName = monstersWithHp.Keys.ElementAt(index);
                    string lowerCasedCurrentMonster = currentMonsterName.ToLower();

                    if (lowerCasedCurrentMonster.Contains(lowerCasedUserInput))
                    {
                        int currentMonsterHp = monstersWithHp[currentMonsterName];
                        filteredMonstersByName.Add(currentMonsterName, currentMonsterHp);
                    }
                }
            }
            else
            {
                Console.WriteLine("No input provided. Showing all monsters. \n");

                for (int index = 0; index < monstersWithHp.Count; ++index)
                {
                    Console.WriteLine(monstersWithHp.Keys.ElementAt(index));
                }
            }

            if (filteredMonstersByName.Count == 0)
            {
                Console.WriteLine("None of the monsters starts with these letters. \n");
            }
            else
            {
                for (int index = 0; index < filteredMonstersByName.Count; ++index)
                {
                    Console.WriteLine(filteredMonstersByName.Keys.ElementAt(index) + " - " + filteredMonstersByName.Values.ElementAt(index) + " HP");
                }
            }
        }
    }
}