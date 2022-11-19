using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;

namespace HMS.Interfaces.Implementation
{
    public class BookingManager : IBookingManager
    {
        IStaffManager staffManager = new StaffManager();
        public static List<Booking> listOfBookings = new List<Booking>();
        public string FileDirect = "@./Files";
        public string FilePath = "./Files/booking.txt";
        public void CreateBooking(Customer customer, DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, string roomId, bool isavailable, int roomtype, int duration)
        {
            Random random = new Random();
           int id = listOfBookings.Count + 1;
           bool ischecked = false;

           if (checkInDate == DateTime.Now) ischecked = true;
          
           string customernumber = customer.CustomerNumber;

            if(roomtype == 1)
            {
                customer.Wallet -= 200000 * duration;
            }

            else if(roomtype == 2)
            {
                customer.Wallet -= 100000 * duration;
            }

            else if (roomtype == 3)
            {
                customer.Wallet -= 50000 * duration;
            }

            else if (roomtype == 4)
            {
                customer.Wallet -= 25000 * duration;
            }

            else if (roomtype == 5)
            {
                customer.Wallet -= 15000 * duration;
            }

            else
            {
                Console.WriteLine("Invalid Input");
            }

           Booking booking = new Booking ( id, bookingDate, checkInDate, checkOutDate, ischecked, isavailable, roomtype, duration);
           listOfBookings.Add(booking);
           using(StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(booking.ConvertToFileFormat());
            }
           Console.WriteLine($"You have successfully booked a room \nDuration: {duration} \nAmount {customer.Wallet}");
        }

        public void DeleteBooking(DateTime checkInDate)
        {
            Console.Write("Enter your email: ");
            string mail = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);
            if (staff.Roles.ToLower() == "manager")
            {
            Booking book = GetBooking(checkInDate);
            if (book != null)
            {
                listOfBookings.Remove(book);
            }
            else
            {
                Console.WriteLine("Booking not found");
            }
            }
           
        }
        public void DeleteBooking()
        {
            Console.Write("Enter your email: ");
            string mail = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            
            Staff staff = staffManager.GetStaff(mail);
            if (staff.Roles.ToLower() == "manager" || staff.Roles.ToLower() == "receptionist")
            {
            Console.Write("Enter email of customer to delete: ");
            DateTime bookingDate = DateTime.Parse(Console.ReadLine().Trim());
            foreach(var item in listOfBookings)
            {
                if (item.BookingDate == bookingDate)
                {
                    listOfBookings.Remove(item);
                    ReWriteFile();
                    break;
                }
            }
            }
            
        }

        public void GetAllBooking()
        {
             Console.Write("Enter the manager's email to update a staff: ");
            string mail = Console.ReadLine();

            Console.Write("Enter the manager's password to update a staff: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);
            if (staff.Roles.ToLower() == "manager")
            {
            foreach (var item in listOfBookings)
            {
                Console.Write($"{item.Id}\t{item.BookingDate}\t{item.CheckInDate}\t{item.CheckOutDate}\t{item.isChecked}");
            }
            Console.WriteLine();
            }
            
        }

        public Booking GetAvailableRooms(int roomType, DateTime bookingDate, int duration)
        {
            foreach (var item in listOfBookings)
            {
                if (item.RoomType == roomType && item.BookingDate == bookingDate && item.Duration == duration )
                {
                    Console.WriteLine($"You have successfully booked a room for yourself");
                }
            }

            return null;
        }

        public Booking GetBooking(int id, DateTime bookingDate)
        {
            foreach(var booking in listOfBookings)
            {
                if (booking.Id == id && booking.BookingDate == bookingDate)
                {
                    return booking;
                }
            }
            return null;
        }

        public Booking GetBooking(DateTime bookingDate)
        {
            foreach (var booking in listOfBookings)
            {
                if (booking.BookingDate == bookingDate)
                {
                    return booking;
                }
            }
            return null;
        }

        public void ReadFromFile()
        {
            if (!Directory.Exists(FileDirect))
            {
                Directory.CreateDirectory(FileDirect);
            }
            if (!File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.CreateNew);
                fs.Close();
            }
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string bookinginfo = reader.ReadLine();
                    listOfBookings.Add(Booking.ConvertToBooking(bookinginfo));
                }
            }
        }

        public void ReWriteFile()
        {
           File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var booking in listOfBookings)
                {
                    writer.WriteLine(booking.ConvertToFileFormat());
                }
            } 
        }

        public void UpdateBooking()
        {
            Console.Write("Enter the manager's email to update booking: ");
            string mail = Console.ReadLine();

            Console.Write("Enter the manager's password to update booking: ");
            string password = Console.ReadLine();
            
            Staff staff = staffManager.GetStaff(mail);

            if (staff.Roles.ToLower() == "manager")
            {
            Console.Write("Enter the bookingdate to Update: ");
            DateTime bookingdate = DateTime.Parse(Console.ReadLine().Trim());
            Booking bookingdateToUpdate = GetBooking(bookingdate);
            if (bookingdateToUpdate != null)
            {
                Console.Write("Update checkInDate: ");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine().Trim());
                bookingdateToUpdate.CheckInDate = checkInDate;

                Console.Write("Update checkOutDate: ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine().Trim());
                bookingdateToUpdate.CheckOutDate = checkOutDate;

                Console.Write("Update Duration:  ");
                int duration = int.Parse(Console.ReadLine().Trim());
                bookingdateToUpdate.Duration = duration;
                ReWriteFile();
                Console.WriteLine("booking updated successfully");
            }

            else
            {
                Console.WriteLine("booking not found");
            }
            }
        
        }
    }

}