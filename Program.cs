using System;

namespace backpack
{
    class Program
    {
        // måste ligga i class program och vara static för att kunna nås av alla metoder 
        static string[] backpack = new string[5];

        static void Main(string[] args)
        {
            // menyloop
            while (true)
            {
                Console.WriteLine("Välkommen till ryggsäcken!");
                Console.WriteLine("[1] Lägg till ett föremål");
                Console.WriteLine("[2] Skriv ut innehållet");
                Console.WriteLine("[3] Rensa innehållet");
                Console.WriteLine("[4] Avsluta");

                // user input
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    // lägg till
                    case "1":
                        AddContents();
                        break;

                    // skriv ut
                    case "2":
                        ShowContents();
                        break;

                    // töm
                    case "3":
                        EmptyContents();
                        break;

                    // avsluta
                    case "4":
                        return;

                    default:
                        Console.WriteLine("Vänligen ange 1,2,3 eller 4!");
                        break;
                }
            }
        }

        // metod som lägger till föremål i ryggsäcken
        static void AddContents()
        {
            Console.Write("Vad vill du lägga till? ");
            string addItem = Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {
                // om in dex är under 5 och om det finns plats
                if (i < 5 && backpack[i] == null)
                {
                    // lägg i nåt
                    backpack[i] = addItem;
                    return;
                }
                // annars om sista index har nåtts och platsen är full
                else if (i == 4 && backpack[i] != null)
                {
                    System.Console.WriteLine("Ryggsäcken är full!");
                }
            }
        }

        // metod som visar föremål i ryggsäcken
        static void ShowContents()
        {
            // om första platsen är tom
            if (backpack[0] == null)
            {
                Console.WriteLine("Ryggan är tom!");
            }

            // annars om det finns något i säcken
            else
            {
                Console.WriteLine("Ryggan innehåller:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Plats " + (i + 1) + ": " + backpack[i]);
                }
            }
        }

        // metod som tömmer ryggsäcken
        static void EmptyContents()
        {
            Console.WriteLine("Du har tömt ryggan.");
            for (int i = 0; i < 5; i++)
            {
                backpack[i] = null;
            }
        }
    }
}