using System;
using System.Collections.Generic;
using System.Linq;

namespace GalacticQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Galactic Quest!");

            CreateAndDisplayPlayerStats();

            OpenMainMenu();
        }

        private static void CreateAndDisplayPlayerStats()
        {
            Console.Write("\n");

            List<(string, int)> items = new List<(string, int)>() { ("Excalibur", 500), ("Tessaiga", 1000) };

            Player player = new Player(50, 1, items);

            player.ShowProfile();

            Console.WriteLine("Testing damage update...");
            player.UpdateHp(-60);
            Console.WriteLine($"After updating HP: {player.Hp}");

        }

        internal static void OpenMainMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Write("\n");
                Console.WriteLine("Select your option and press Enter: \n 1.Travel \n 2.Journal \n 3.Exit \n");

                string input = Console.ReadLine();
                int.TryParse(input, out int readOption);

                try
                {
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
                            throw new Exception("Invalid selection detected.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error");
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
            Console.Write("\n");
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
            Console.Write("\n");
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
            return new List<string>
            {
                "Glorbazorg", "Xenotutzi", "Ignifax", "Kryostasis",
                "Nighthorn", "Leviathan-Maw", "Hydro-King Aqueron", "Stonemouth"
            };
        }

        internal static Dictionary<string, int> CreateMonstersWith(string hpOrAttack, List<string> monstersList)
        {
            Dictionary<string, int> monstersDictionary = new Dictionary<string, int>();
            Random randomGenerator = new Random();

            for (int i = 0; i < monstersList.Count; ++i)
            {
                string monsterKey = monstersList[i];
                int monsterValue = hpOrAttack == "hp" ? randomGenerator.Next(10, 100) : randomGenerator.Next(1, 20);
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
            Console.Write("\n");
            for (int index = 0; index < monstersWithAttack.Count; ++index)
            {
                Console.WriteLine(monstersWithAttack.Keys.ElementAt(index) + " - " + monstersWithAttack.Values.ElementAt(index) + " ATT");
            }
            Console.Write("\n");
            ShowMonstersOptions(monstersWithHp);
        }

        internal static void ShowMonstersOptions(Dictionary<string, int> monstersWithHp)
        {
            Console.WriteLine("Press 1 to go back or 2 to filter monsters based on name");
            int.TryParse(Console.ReadLine(), out int userOption);
            switch (userOption)
            {
                case 1: break;
                case 2: FilterMonstersByName(monstersWithHp); break;
                default: Console.WriteLine("Invalid Option."); break;
            }
        }

        internal static void FilterMonstersByName(Dictionary<string, int> monstersWithHp)
        {
            Console.WriteLine("Enter letters to filter monsters: ");
            string? userInput = Console.ReadLine();
            Console.Write("\n");

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("No input provided. Showing all monsters.");
                foreach (var monster in monstersWithHp) Console.WriteLine(monster.Key);
                return;
            }

            var filtered = monstersWithHp.Where(m => m.Key.ToLower().Contains(userInput.ToLower())).ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("None of the monsters starts with these letters.\n");
            }
            else
            {
                foreach (var monster in filtered)
                {
                    Console.WriteLine($"{monster.Key} - {monster.Value} HP");
                }
            }
        }
    }
}

//             Console.WriteLine("===================================\n");
