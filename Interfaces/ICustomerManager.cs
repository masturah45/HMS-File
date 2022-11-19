using System;
using HMS.Model;
namespace HMS.Interfaces
{
    public interface ICustomerManager
    {
        public void CreateCustomer (string nextOfKin, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, int roomtype);
        public void UpdateCustomer ();
        public void DeleteCustomer ();
        public void GetAllCustomer();
        public Customer GetCustomer (string email);
        public Customer Login (string email, string password);
        public void AddMoneyToWallet (string email, double amount);
        public void CheckWallet (string email,double amount);
        public Customer RescheduleBooking (int id, int roomtype, int bookingdate, string duration);
        public void ReadFromFile();
        public void ReWriteFile();
    }
}