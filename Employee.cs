using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace badge_maker
{
    public class Employee
    {
        public string FirstName;
        public string LastName;
        public int Id;
        public string PhotoUrl;

        public Employee(string firstName, string lastName, int id, string photoUrl) {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }

        public string GetAll() {
            return Id.ToString() + " | " + FirstName + " " + LastName + " | " + PhotoUrl; 
        }
        public string GetCSV() {
            return Id.ToString() + "," + FirstName + " " + LastName + "," + PhotoUrl; 
        }

        public string GetFullName() {
            return FirstName + " " + LastName;
        }
        public int GetId() {
            return Id;
        }
        public string GetPhotoUrl() {
            return PhotoUrl;
        }
    }
}