using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace slots
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Random rnd = new Random();

            string message = "";

            string[] fruits = { "cat", "dog", "lion", "zebra", "parrot", "meerkat", "penguin", "dolphin", "spider" };

            string slot1 = "X";
            string slot2 = "X";
            string slot3 = "X";

            int credits = 5;

            string choice = "";
            
            while (credits > 0 || choice != "n")
            {
                menu(slot1, slot2, slot3, credits, message);
                message = "";
                Console.WriteLine("\nEnter credit: (y/n)");
                choice = Console.ReadLine();

                if (choice == "n")
                {
                    break;
                }

                credits--;

                animation(slot1, slot2, slot3, credits, message, fruits, rnd);

                slot1 = fruits[rnd.Next(0, 9)];
                slot2 = fruits[rnd.Next(0, 9)];
                slot3 = fruits[rnd.Next(0, 9)];

                if (slot1 == slot2)
                {
                    credits += 2;
                    message += "Matching pair, +2 credits! ";
                }
                if (slot2 == slot3)
                {
                    credits += 2;
                    message += "Matching pair, +2 credits! ";
                }
                if (slot1 == slot3)
                {
                    credits += 2;
                    message += "Matching pair, +2 credits! ";
                }

                if (slot1 == slot2 && slot2 == slot3)
                {
                    credits += 5;
                    message += "Three of a kind, +5 credits! ";
                }

                if (slot1 == "cat" || slot2 == "cat" || slot3 == "cat")
                {
                    credits += 1;
                    message += "Lucky cat, +1 credit! ";
                }

                if ( (slot1 == "cat" || slot2 == "cat" || slot3 == "cat") & (slot1 == "dog" || slot2 == "dog" || slot3 == "dog"))
                {
                    credits += 5;
                    message += "It's raining cats and dogs, +5 credits! ";
                }

            }


        }
        static void menu(string slot1, string slot2, string slot3, int credits, string message)
        {
            Console.Clear();
            Console.WriteLine("Credits: {0}\n", credits);
            Console.WriteLine($"| || {slot1} || {slot2} || {slot3} || |");
            Console.WriteLine("\n" + message);
        }

        static void animation(string slot1, string slot2, string slot3, int credits, string message, string[] fruits, Random rnd)
        {
            int yay = 0;
            for (int i = 0; i < 10; i++)
            {

                yay += 10;

                menu(slot1, slot2, slot3, credits, message);
                slot1 = fruits[rnd.Next(0, 9)];
                slot2 = fruits[rnd.Next(0, 9)];
                slot3 = fruits[rnd.Next(0, 9)];
                Thread.Sleep(yay);

            }


        }
    }
}
