using System;
using System.Collections.Generic;

namespace backpack
{
    class Program
    {
        public enum MenuType 
        {
            MainMenu,
            ReplaceContentMenu
        };

        // Bag variables
        static int          maxBagSize  = 5;
        static string []    bagContent  = new string[maxBagSize];
        static int          itemsInBag  = 0;

        // Application variables
        static bool         isRunning   = true;
        static string       msgLog      = "";
        
        static void Main(string[] args)
        {
            string[]     menuOption  = {"Lägg till", "Visa innehåll", "Töm ryggsäcken", "Stäng din ryggsäck"};
            int          menuCursor  = 0;
            
            while(isRunning)
            {
                //menu
                Console.Clear();
                Console.WriteLine(bagContent.Length);
                Console.WriteLine("Välkommen till din ryggsäck!");
                Console.WriteLine("-----------------------------");
                for (int i = 0; i < menuOption.Length; i++) {
                    
                    string toDraw = "  ";
                    if (menuCursor == i) {
                        toDraw = "> ";
                    }
                    Console.WriteLine(toDraw + menuOption[i]);
                }
                Console.WriteLine("-----------------------------\n");

                // "Write messages collected through the loop
                Console.Write(msgLog);
                msgLog = "";

                // if method returns false, exit the application
                isRunning = UpdateMenuOption(ref menuCursor, menuOption.Length -1, MenuType.MainMenu);
            }
        }

        static bool UpdateMenuOption(ref int cursor, int maxValueOfMenu, MenuType menuType)
        {
            // Read userinput
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            
            // Update cursor and clamp it to be within bounds of array
            switch (pressedKey.Key)
            {
                // Navigate menu upwards, clamp to 0
                case ConsoleKey.UpArrow:
                {
                    cursor--;
                    cursor = Math.Clamp(cursor, 0, maxValueOfMenu);
                    break;
                }

                // Navigate menu downwards, clamp to menuOption length
                case ConsoleKey.DownArrow:
                {
                    cursor++;
                    cursor = Math.Clamp(cursor, 0, maxValueOfMenu);
                    break;
                }

                // Quit the program by secret hax key
                case ConsoleKey.Escape:
                {
                    return false;
                }

                // Execute command
                case ConsoleKey.Enter:
                {
                    if (menuType == MenuType.MainMenu) {
                        return OnPressEnter_MainMenu(cursor);                    
                    }
                    else if (menuType == MenuType.ReplaceContentMenu) {
                        // Return false to replace content on current cursorpos
                        return false;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }

            return true;
        }

        static bool OnPressEnter_MainMenu(int cursor)
        {
            // Add content
            if (cursor == 0) {
                AddItemToBag(ref bagContent);
            }

            // Print content
            else if (cursor == 1) {
                PrintBagContent(bagContent);
            }

            // Clear content 
            else if (cursor == 2) {
                ClearBagContent(ref bagContent);
            }
            
            // Exit, returns false to set isRunning
            else if (cursor == 3) {
                Console.WriteLine("...*zzziiiiipp sound");
                return false;
            }

            return true;
        }
                
        static void AddItemToBag(ref string[] bagContent)
        {
            Console.WriteLine("Vad vill du lägga i din väska?\t\t\t\t\t"); // tab is to fix ux fluff
            Console.Write(": ");
            string addItem = Console.ReadLine();
            
            // If no input, return
            if (addItem == "") {
                msgLog += "Luften du la i väskan sipprade tyvärr ut...";
                return;
            }

            if (itemsInBag != maxBagSize) {
                msgLog += "Väskan innehåller nu föremålet: " + addItem;
                bagContent[itemsInBag] = addItem;
                itemsInBag++;
            }
            // If bag is full, start replaceItem loop
            else {
                OnBagIsFull(ref bagContent, addItem);
            }
        }
       
        static void ReplaceItemInBag(ref string[] bagContent, int cursor, string addItem)
        {
            msgLog += new string("Du slängde ut '" + bagContent[cursor] + "' för att ge plats åt '" + addItem + "'.");
            bagContent[cursor] = addItem;
        }

        static void PrintBagContent(string[] bagContent)
        {
            // If bag is empty, return
            if (itemsInBag == 0) {
                msgLog = "Du har inget i din väska";
                return;
            }
                
            msgLog += "I din väska har du följande\n";
            for (int i = 0; i < itemsInBag; i++)
            {
                msgLog += (" " + bagContent[i] + "\n");
            }
        }

        static void ClearBagContent(ref string[] bagContent)
        {
            // If bag is empty, return
            if (itemsInBag == 0) {
                msgLog = "Din väska är redan tom silly...";
                return;
            }


            // Reset bag values
            itemsInBag = 0;
            string[] clearBag = new string[5];
            clearBag.CopyTo(bagContent, 0);

            msgLog = "Du tömde innehållet av din väska i närmaste soptunna";
        }

        static void OnBagIsFull(ref string[] bagContent, string addItem)
        {
            int cursor = 0;
            
            // Set console cursor to 2 lines above to erase that line of code for nicer ux.
            int clearConsoleFromHere = Console.CursorTop - 2;
            
            while (true) 
            {
                Console.SetCursorPosition(0, clearConsoleFromHere);
                Console.WriteLine("Din väska är tyvärr full! Du måste plocka ut ett föremål för att kunna lägga i {0}.", addItem);
                Console.WriteLine("Vad vill du ta bort?", addItem);
    
                for (int i = 0; i < itemsInBag; i++)
                {
                    string toDraw = "  ";
                    if (cursor == i) {
                        toDraw = "> ";
                    }
                    Console.WriteLine(toDraw + bagContent[i]);
                }
                
                // When enter is pressed, replace item on cursor pos to the new item
                if (!UpdateMenuOption(ref cursor, bagContent.Length -1, MenuType.ReplaceContentMenu)) {
                    ReplaceItemInBag(ref bagContent, cursor, addItem);
                    break;
                }
            }
        }
    }
}
