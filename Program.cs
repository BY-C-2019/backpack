using System;

namespace backpack
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            //Backpackpt1();
            backpackpt2();

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
        static void backpackpt2()
        {
            string[] contentArray = new string[5];
            string item;
            int index=0;
            int choice = 0;
            System.Console.WriteLine("Welcome to your digtal backpack.");

            while(true)
            {
                
                System.Console.WriteLine("\n");
                System.Console.WriteLine("[1] Add an item");
                System.Console.WriteLine("[2] View the contents");
                System.Console.WriteLine("[3] Delete all the items");
                System.Console.WriteLine("[4] Exit");

                //En try/catch för att undvika fel input.
                try
                {
                choice =Convert.ToInt32( Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Wrong input, only numbers 1-4 is allowed.");
                }
                
                switch(choice)
                {
                    case 1:
                    {
                        // Add an item
                        // Jag har valt en if sats för att se till att man inte hamnar utanför arrayen.
                        // tänkte använda en for-loop först men då blir jag ju tvingad att mata in alla
                        //värden med en gång och det vill jag inte göra så det blev if-sats och index++.
                        if (index == contentArray.Length)
                        {
                            System.Console.WriteLine("your backpack is full");
                            break;
                        }
                        
                        System.Console.Write("What do you want to add: ");
                        item = Console.ReadLine();
                        contentArray[index]= item;
                        System.Console.WriteLine(item +" has been added to your backpack");
                        index++; 
                    }
                    break;
                    
                    case 2:
                    {
                        // Show contents
                        // En for-loop som föreskrevs använde jag här, man hade också kunnat välja
                        // att använda en foreach-loop för att säkerställa att man inte hamnade utanför 
                        // arrayen, men eftersom jag skulle använda for så blev det for.
                        System.Console.WriteLine("The items in your backpack:");
                        for(index=0; index < contentArray.Length;index++)
                        {
                            System.Console.WriteLine("{0}. {1}",index+1, contentArray[index]);
                        }
                        
                    }
                    break;

                    case 3:
                    {
                        //Empty the backpack 
                        
                        //Jag har för mig att det ska finnas ett annat "noob"sätt att cleara en array 
                        //men jag kom inte ihåg det så jag googlade fram den här lösningen.
                        //Arra.clear tar bort alla värden som finns i listan och "index=0" placerar den på första
                        //platsen i arrayen så att jag kan mata in nya värden.
                        System.Console.WriteLine("Your backpack is now empty.");
                        Array.Clear(contentArray,0,contentArray.Length);
                        index=0;
                    }
                    break;

                    case 4:
                    {
                        //End program
                        System.Console.WriteLine("You have chosen to exit the backpack, have a nice day.");
                    }
                    return;
    
                }    
            }
        }
    }
}
