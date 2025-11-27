using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Trimble_C3
{
    // O clasă simplă pentru a ține minte viața și atacul,
    // deoarece cerința cere ambele valori asociate unui monstru.
    public class MonsterStats
    {
        public int Health { get; set; }
        public int Attack { get; set; }
    }

    internal class Program
    {
        // Definim dicționarul la nivel de clasă (static) ca să îl putem accesa de oriunde
        static Dictionary<string, MonsterStats> monsters = new Dictionary<string, MonsterStats>();

        static void Main(string[] args)
        {
            // 1. Populăm lista cu 6-7 monștri (Populate the list)
            InitializeMonsters();

            bool isRunning = true;

            while (isRunning)
            {
                // Afișăm opțiunile principale
                Console.Clear(); // Curăță consola pentru a arăta curat
                Console.WriteLine("=== MAIN MENU ===");
                Console.WriteLine("Select One Option:");
                Console.WriteLine("1. Monsters");
                Console.WriteLine("2. Travel");
                Console.WriteLine("3. Journal");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");

                string input = Console.ReadLine();
                // Folosim TryParse pentru a evita erorile dacă utilizatorul scrie litere
                if (int.TryParse(input, out int choice))
                {
                    // Facem cast la Enum pentru a folosi switch-ul frumos
                    switch ((GameOptions)choice)
                    {
                        case GameOptions.Monsters:
                            Menu_Monsters();
                            break;
                        case GameOptions.Travel:
                            Menu_Travel();
                            break;
                        case GameOptions.Journal:
                            Menu_Journal();
                            break;
                        case GameOptions.Exit:
                            Console.WriteLine("Exiting the game. Goodbye!");
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Press any key to try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                    Console.ReadKey();
                }
            }
        }

        // --- METODE PENTRU LOGICA JOCULUI ---

        static void InitializeMonsters()
        {
            // Adăugăm monștrii cu HP și Attack
            monsters.Add("Goblin", new MonsterStats { Health = 50, Attack = 10 });
            monsters.Add("Orc", new MonsterStats { Health = 120, Attack = 25 });
            monsters.Add("Dragon", new MonsterStats { Health = 500, Attack = 100 });
            monsters.Add("Slime", new MonsterStats { Health = 20, Attack = 5 });
            monsters.Add("Vampire", new MonsterStats { Health = 150, Attack = 40 });
            monsters.Add("Werewolf", new MonsterStats { Health = 180, Attack = 45 });
            monsters.Add("Skeleton", new MonsterStats { Health = 40, Attack = 15 });
        }

        // Meniul pentru Monștri (cerința detaliată)
        static void Menu_Monsters()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine("=== MONSTERS LIST ===");

                // Afișăm toți monștrii
                DisplayMonsters(monsters);

                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Filter by Name");
                Console.WriteLine("2. Back");
                Console.Write("Choice: ");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    // Logica de filtrare
                    Console.Write("\nEnter sequence to search: ");
                    string filter = Console.ReadLine();
                    FilterMonsters(filter);
                }
                else if (input == "2")
                {
                    // Back înseamnă ieșirea din acest while, revenind la Main Menu
                    inMenu = false;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }

        static void DisplayMonsters(Dictionary<string, MonsterStats> listToDisplay)
        {
            Console.WriteLine($"{"Name",-15} | {"HP",-5} | {"Attack",-5}");
            Console.WriteLine(new string('-', 30));

            foreach (var kvp in listToDisplay)
            {
                Console.WriteLine($"{kvp.Key,-15} | {kvp.Value.Health,-5} | {kvp.Value.Attack,-5}");
            }
        }

        static void FilterMonsters(string searchSequence)
        {
            Console.Clear();
            Console.WriteLine($"=== SEARCH RESULTS FOR: '{searchSequence}' ===\n");

            // Căutăm monștrii care conțin secvența (case insensitive)
            var filtered = monsters.Where(m => m.Key.IndexOf(searchSequence, StringComparison.OrdinalIgnoreCase) >= 0)
                                   .ToDictionary(m => m.Key, m => m.Value);

            if (filtered.Count > 0)
            {
                DisplayMonsters(filtered);
            }
            else
            {
                // Cerința: display message accordingly and all the monsters
                Console.WriteLine("No monsters found matching that sequence.");
                Console.WriteLine("Here is the full list instead:\n");
                DisplayMonsters(monsters);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Meniul Travel
        static void Menu_Travel()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine("=== TRAVEL MENU ===");
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. Search For Items");
                Console.WriteLine("3. Back To Ship"); // This acts as Back
                Console.Write("Choice: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Exploring... (Press any key)");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Searching... (Press any key)");
                        Console.ReadKey();
                        break;
                    case "3":
                        inMenu = false; // Back to main menu
                        break;
                    default:
                        break;
                }
            }
        }

        // Meniul Journal
        static void Menu_Journal()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine("=== JOURNAL ===");
                Console.WriteLine("1. Monsters");
                Console.WriteLine("2. Planets");
                Console.WriteLine("3. Items");
                Console.WriteLine("4. Back");
                Console.Write("Choice: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Cerința: Journal will open the menu: Monsters
                        // Reutilizăm logica de la Monștri
                        Menu_Monsters();
                        break;
                    case "2":
                        Console.WriteLine("Planets page... (Press any key)");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Items page... (Press any key)");
                        Console.ReadKey();
                        break;
                    case "4":
                        inMenu = false;
                        break;
                }
            }
        }
    }
}