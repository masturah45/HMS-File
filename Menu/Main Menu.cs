using System;
using HMS.Interfaces;
using HMS.Interfaces.Implementation;

namespace HMS.Menu
{
    public static class MainMenu
    {
        static CustomerMenu customerMenu = new CustomerMenu();
        static StaffMenu staffMenu = new StaffMenu();
       static  IStaffManager staffManager = new StaffManager();
        public static void WelcomePage()
        {
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("///////////// Welcome to Five Stars Hotel///////////////");
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("////////////////////////////////////////////////////////");

            Console.WriteLine("Enter 1 as Staff\nEnter 2 as Customer\nEnter 3 to shut down application");
            int opt = int.Parse(Console.ReadLine());
            bool isExit = false;
            while (!isExit)
            {
                switch(opt)
                {
                case 0 :
                Console.WriteLine("Program Closed");
                break;

                case 1 :
                Console.WriteLine("<<<<<<<<<<< Welcome to the Staff Main Menu >>>>>>>>>>>");
                staffMenu.Staff();
                break;

                case 2 :
                Console.WriteLine("<<<<<<<<<< Welcome to the Customer Main Menu >>>>>>>>>>");
                customerMenu.Customer();
                break;

                case 3 :
                Console.WriteLine("Shutting Down Application...........");
                isExit = true;
                break;


                default :
                Console.WriteLine("Invalid input");
                WelcomePage();
                break;

            }
            }
            
            Console.WriteLine("");
            
        }
    }
}