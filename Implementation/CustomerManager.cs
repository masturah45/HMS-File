using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;

namespace HMS.Interfaces.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        IStaffManager staffManager = new StaffManager();
        public static List<Customer> listOfCustomers = new List<Customer>();
        public string FileDirect = "@./Files";
        public string FilePath = "./Files/customer.txt";
        public void AddMoneyToWallet(string email, double amount)
        {
            Customer adm = GetCustomer(email);
            if (adm != null)
            {
                adm.Wallet += amount;
                Console.WriteLine($"{amount} successfully added to wallet and balance is {adm.Wallet}");

            }
            else
            {
                Console.WriteLine("customer not found");
            }
        }

        public void CheckWallet(string email, double amount)
        {
            Customer ad = GetCustomer(email);
            if (ad != null)
            {
                if (ad.Wallet > 0 )
                {
                    Console.WriteLine("You have checked your balance");
                }

            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public void CreateCustomer(string nextOfKin, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, int roomtype)
        {

            Random rand = new Random();
            int id = listOfCustomers.Count + 1;
            double wallet = 0;
            string customernumber = "MTC/CTM" + rand.Next(100, 999).ToString();
            Customer customer = new Customer(wallet, nextOfKin, customernumber, id, firstName, lastName, email, password, dateOfBirth, phoneNumber, roomtype);
            listOfCustomers.Add(customer);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(customer.ConvertToFileFormat());
            }
            Console.WriteLine($"Thank you {customer.FirstName}, your customer number is {customer.CustomerNumber}");
        }

        public void DeleteCustomer()
        {
        
            Console.Write("Enter email of customer to delete: ");
            string email = Console.ReadLine().Trim();
            foreach (var item in listOfCustomers)
            {
                if (item.Email == email)
                {
                    listOfCustomers.Remove(item);
                    ReWriteFile();
                    break;
                }
                else
                {
                    System.Console.WriteLine("customer not found");
                }
              
            }
            
          
        }

        public void GetAllCustomer()
        {
             Console.Write("Enter the manager's email to update a staff: ");
            string mail = Console.ReadLine();

            Console.Write("Enter the manager's password to update a staff: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.GetStaff(mail);
            if (staff.Roles.ToLower() == " manager")
            {
            foreach (var item in listOfCustomers)
            {
                Console.WriteLine($"{item.Wallet}+++{item.NextOfKin}+++{item.CustomerNumber}+++{item.Id}+++{item.FirstName}+++{item.LastName}+++{item.Email}+++{item.Password}+++{item.DateOfBirth}+++{item.PhoneNumber}+++{item.RoomType}");
            }
            }
            
        }

        public Customer GetCustomer(string email)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Login(string email, string password)
        {
            foreach (var item in listOfCustomers)
            {
                if (item.Email == email && item.Password == password)
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
                FileStream fs = new FileStream(FilePath, FileMode.Create);
                fs.Close();
            }
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string customerinfo = reader.ReadLine();
                    listOfCustomers.Add(Customer.ConvertToCustomer(customerinfo));
                }
            }
        }

        public Customer RescheduleBooking(int id, int roomtype, int bookingdate, string duration)
        {
            foreach (var item in listOfCustomers)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReWriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var customer in listOfCustomers)
                {
                    writer.WriteLine(customer.ConvertToFileFormat());
                }
            }
        }

        public void UpdateCustomer()
        {
           
            Console.Write("Enter email of Customer to Update: ");
            string email = Console.ReadLine().Trim();
            Customer customerToUpdate = GetCustomer(email);
            if (customerToUpdate != null)
            {
                Console.Write("Update First Name: ");
                string firstName = Console.ReadLine().Trim();
                customerToUpdate.FirstName = firstName;

                Console.Write("Update Last Name: ");
                string lastName = Console.ReadLine().Trim();
                customerToUpdate.LastName = lastName;

                Console.Write("Update NextOfKin:  ");
                string nextOfKin = Console.ReadLine().Trim();
                customerToUpdate.NextOfKin = nextOfKin;
                ReWriteFile();
                Console.WriteLine("customer updated successfully");
            }

  
        }
    }
}