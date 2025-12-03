using System;
using System.Collections.Generic;

namespace GalacticQuest
{
    internal class Player
    {
        public int Hp { get; private set; }
        public int Level { get; private set; }

        public int Credits { get; private set; }

        public List<(string Name, int Value)> Items { get; private set; }

        public Player(int hp, int level, List<(string, int)> items)
        {
            Hp = hp;
            Level = level;
            Items = items;
            Credits = 100;
        }

        public void ShowProfile()
        {
            Console.WriteLine($"\n--- Player Profile ---");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"HP: {Hp}");
            Console.WriteLine($"Credits: {Credits}");
            Console.WriteLine("Inventory:");

            if (Items.Count > 0)
            {
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item.Name} (Value: {item.Value})");
                }
            }
            else
            {
                Console.WriteLine("- Empty");
            }
            Console.WriteLine("----------------------\n");
        }

        public void UpdateHp(int amount)
        {
            Hp += amount;

            if (Hp <= 0)
            {
                Hp = 0;
                OnDeath();
            }
        }

        private void OnDeath()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n===================================");
            Console.WriteLine("           YOU HAVE DIED           ");
            Console.WriteLine("   Game Over - The Galaxy is lost  ");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }

        public void UpdateCredits(int amount)
        {
            if (Credits + amount < 0)
            {
                Console.WriteLine("Not enough credits for this transaction!");
            }
            else
            {
                Credits += amount;
                Console.WriteLine($"Credits updated. Current balance: {Credits}");
            }
        }

        public void AddItem((string Name, int Value) item)
        {
            Items.Add(item);
            Console.WriteLine($"Item added: {item.Name}");
        }

        public void RemoveItem(string itemName)
        {
            var itemToRemove = Items.Find(i => i.Name == itemName);

            if (!string.IsNullOrEmpty(itemToRemove.Name))
            {
                Items.Remove(itemToRemove);
                Console.WriteLine($"Item removed: {itemName}");
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }
    }
}
