using System;
using HMS.Model;

namespace HMS.Interfaces
{
    public interface IStaffManager
    {
        public void CreateStaff (string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, string roles);
        public void UpdateStaff ();
        public void DeleteStaff ();
        public Staff GetStaff (string email);
        public void GetAllStaff();
        public Staff Login (string email, string password);
        public void GetAllStaffForUpdate();
        public void ReadFromFile();
        public void ReWriteFile();
    }
}