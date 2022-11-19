using System;
namespace HMS.Model
{
    public class Staff : User
    {
        public string Roles {get; set;}
        public string Staffnumber {get;set;}

        public Staff(string roles, string staffnumber,  int id, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber): base (id, firstName, lastName, email, password, dateOfBirth, phoneNumber)
        {
            Roles = roles;
            Staffnumber = staffnumber;
        }

        public string ConvertToFileFormat()
        {
            return $"{Roles}+++{Staffnumber}+++{Id}+++{FirstName}+++{LastName}+++{Email}+++{Password}+++{DateOfBirth}+++{PhoneNumber}"; 
        }
        public static Staff ConvertToStaff(string staffinfo)
        {
            string[] info = staffinfo.Split("+++");
            return new Staff(info[0], info[1], int.Parse(info[2]),info[3],info[4],info[5], info[6], DateTime.Parse(info[7]),info[8]);
        }
    }
}