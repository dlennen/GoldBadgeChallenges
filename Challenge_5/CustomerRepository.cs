using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class CustomerRepository
    {
        List<Customer> _listOfCustomers = new List<Customer>();

        public void CreateDummyData()
        {
            string potentialEmail = "We currently have the lowest rates on Helicopter Insurance!";
            string currentEmail = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            string pastEmail = "It's been a long time since we've heard from you, we want you back";
            Customer dummy1 = new Customer("Jake", "Jones", "Potential", potentialEmail);
            Customer dummy2 = new Customer("Emily", "Johnson", "Current", currentEmail);
            Customer dummy3 = new Customer("John", "Carter", "Past", pastEmail);
            Customer dummy4 = new Customer("Angela", "Lindner", "Potential", potentialEmail);
            Customer dummy5 = new Customer("Marcus", "Smith", "Current", currentEmail);
            Customer dummy6 = new Customer("JaKayla", "Bryson", "Past", pastEmail);
            Customer dummy7 = new Customer("Daniel", "Jones", "Potential", potentialEmail);
            AddCustomerToList(dummy1);
            AddCustomerToList(dummy2);
            AddCustomerToList(dummy3);
            AddCustomerToList(dummy4);
            AddCustomerToList(dummy5);
            AddCustomerToList(dummy6);
            AddCustomerToList(dummy7);
        }

        public void AddCustomerToList(Customer customer)
        {
            _listOfCustomers.Add(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return _listOfCustomers;
        }
    }
}
