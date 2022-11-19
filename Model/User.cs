using System;
namespace HMS.Model
{
    public class User
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string PhoneNumber {get; set;}

        public User(int id, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
    }   
}