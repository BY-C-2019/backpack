using System;

namespace backpack
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Backpackpt1();

        }

        static void Backpackpt1()
        {
            string contents="";
            System.Console.WriteLine("Welcome to your digtal backpack.");

            while(true)
            {
                System.Console.WriteLine("\n");
                System.Console.WriteLine("[1] Add an item");
                System.Console.WriteLine("[2] View the contents");
                System.Console.WriteLine("[3] Delete all the items");
                System.Console.WriteLine("[4] Exit");
                string choice = Console.ReadLine();
                
                switch(choice)
                {
                    case "1":
                    {
                        System.Console.Write("What do you want to add: ");
                        string item = Console.ReadLine();
                        System.Console.WriteLine(item +" has been added to your backpack");
                        contents+= " | " + item;
                    }
                    break;
                    
                    case "2":
                    {
                        System.Console.WriteLine("The items in your backpack:");
                        System.Console.WriteLine(contents);
                        if (contents =="")
                        {
                            System.Console.WriteLine("your backpack is empty.");
                        }
                    }
                    break;

                    case "3":
                    {
                        System.Console.WriteLine("Your backpack is now empty.");
                        contents="";
                    }
                    break;

                    case "4":
                    {
                        System.Console.WriteLine("You have chosen to exit the backpack, have a nice day.");
                    }
                    return;
                    
                }

            }
        }
    }
}
