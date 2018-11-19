using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository _customerRepo = new CustomerRepository();
            Customer newCustomer = new Customer();

            Console.WriteLine("What is the new customer's first name?");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("What is the new customer's last name?");
            newCustomer.LastName = Console.ReadLine();

            bool isCustomerTypeValid = false;
            while (isCustomerTypeValid == false)
            {
                Console.WriteLine("What is the new customer's type? ('Potential', 'Current', or 'Past')");
                newCustomer.Type = Console.ReadLine();
                switch (newCustomer.Type)
                {
                    case "Potential":
                        isCustomerTypeValid = true;
                        newCustomer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                    case "Current":
                        isCustomerTypeValid = true;
                        newCustomer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    case "Past":
                        isCustomerTypeValid = true;
                        newCustomer.Email = "It's been a long time since we've heard from you, we want you back";
                        break;
                    default:
                        isCustomerTypeValid = false;
                        Console.WriteLine("Invalid type");
                        break;
                }
            }
        }
    }
}
