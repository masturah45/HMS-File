using System;
namespace HMS.Model
{
    public class Customer : User
    {
        public double Wallet {get; set;}
        public string NextOfKin {get; set;}
        public string CustomerNumber {get; set;}
        public int RoomType {get; set;}

        public Customer(double wallet, string nextOfKin, string customernumber, int id, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, int roomtype): base (id,firstName, lastName, email, password, dateOfBirth, phoneNumber)
        {
            Wallet = wallet;
            NextOfKin = nextOfKin;
            CustomerNumber = customernumber; 
            RoomType = roomtype;
        }


        public string ConvertToFileFormat()
        {
            return $"{Wallet}+++{NextOfKin}+++{CustomerNumber}+++{Id}+++{FirstName}+++{LastName}+++{Email}+++{Password}+++{DateOfBirth}+++{PhoneNumber}+++{RoomType}"; 
        }

         public static Customer ConvertToCustomer(string customerinfo)
        {
            string[] info = customerinfo.Split("+++");
            return new Customer(double.Parse(info[0]),info[1],info[2],int.Parse(info[3]),info[4],info[5],info[6],info[7],DateTime.Parse(info[8]),info[9],int.Parse(info[10]));
        }
    }
}