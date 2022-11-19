using System;
using HMS.Interfaces.Implementation;
using HMS.Menu;

namespace HMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new CustomerManager();
            customer.ReadFromFile();
            var staffManager = new StaffManager();
            staffManager.ReadFromFile();
            var bookingManager = new BookingManager();
            bookingManager.ReadFromFile();
            var roomManager = new RoomManager();
            roomManager.ReadFromFile();
            MainMenu.WelcomePage();
        }
    }
}
