using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;

namespace HMS.Interfaces.Implementation
{
    public class RoomManager : IRoomManager
    {
        IStaffManager staffManager = new StaffManager();
        public static List<Room> listOfRooms = new List<Room>();
        public string FileDirect = "@./Files";
        public string FilePath = "./Files/room.txt";
        public void CreateRoom(string type, double price)
        {   
            Console.Write("Enter your email: ");
            string mail = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);

            if (staff.Roles.ToLower() == "manager")
            {
            Random rand = new Random();
            int id = listOfRooms.Count + 1;
            string roomNumber = "MTC/CTM" + rand.Next(100, 999).ToString();
            Room room = new Room(id, type, price,roomNumber);
            listOfRooms.Add(room);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(room.ConvertToFileFormat());
            }
            Console.WriteLine($"thank you, {room.Type} created succesfully and the room number is {room.RoomNumber}");
            } 
            
        }

        public void DeleteRoom()
        {
            Console.Write("Enter the manager's email to delete a room: ");
            string mail = Console.ReadLine();

            Console.Write("Enter the manager,s password to delete a room: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);

            if (staff.Roles.ToLower() == "manager")
            {
            Console.Write("Enter the type of room u want to delete: ");
            string type = Console.ReadLine().Trim();
            foreach(var item in listOfRooms)
            {
                if (item.Type == type)
                {
                    listOfRooms.Remove(item);
                    ReWriteFile();
                    break;
                }
                else if (staff == null)
                {
                    Console.WriteLine("room not found");
                }
                else
                {
                    Console.WriteLine("this task can not be perform");
                }
            }
            }
            
        }

        public void GetAllRooms()
        {
             Console.Write("Enter the manager's email to update a staff: ");
            string mail = Console.ReadLine();

            Console.Write("Enter the manager's password to update a staff: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);
            if (staff.Roles.ToLower() == "manager")
            {
            foreach (var item in listOfRooms)
            {
                Console.Write($"{item.Id}\t{item.Type}\t{item.Price}\t{item.RoomNumber}");
            }
            Console.WriteLine();
            }
            
        }

        public Room GetRoom(string type)
        {
            foreach (var item in listOfRooms)
            {
                if (item.Type == type)
                {
                    return item;
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
            using(StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string roominfo = reader.ReadLine();
                    listOfRooms.Add(Room.ConvertToRoom(roominfo));
                }
            }
        }

        public void ReWriteFile()
        {
           File.WriteAllText(FilePath, string.Empty);
            using(StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var room in listOfRooms)
                {
                    writer.WriteLine(room.ConvertToFileFormat());
                }
            }
        }

        public void UpdateRoom()
        {
            Console.Write("Enter the the accountant's email to update rooms: ");
            string mail = Console.ReadLine();

            Console.Write("Enter the accountant's password to update room: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);

            if (staff.Roles.ToLower() == "manager" || staff.Roles.ToLower() == "accountant")
            {
            Console.Write("Enter the type of room you want to Update: ");
            string type = Console.ReadLine().Trim();
            Room roomToUpdate = GetRoom(type);
            if (roomToUpdate != null)
            {
                Console.Write("Enter the price of room to update: ");
                double price = double.Parse(Console.ReadLine().Trim());
                roomToUpdate.Price = price;
                ReWriteFile();
                Console.WriteLine("room updated successfully");
            }

            else
            {
                Console.WriteLine("room not found");
            }
            }
            else
            {
                System.Console.WriteLine("This task can not be performed");
            }

          
        }
    }
}