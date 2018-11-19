using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public Customer(string firstName, string lastName, string type, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            Email = email;
        }

        public Customer()
        {

        }
    }
}
