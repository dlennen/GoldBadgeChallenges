using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class ProgramUI
    {
        CustomerRepository _customerRepo = new CustomerRepository();

        public void Run()
        {
            _customerRepo.CreateDummyData();
            RunAdministratorMenu();
        }

        private void RunAdministratorMenu()
        {
            Console.WriteLine("Welcome Komodo Insurance Admistrator.");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nChoose an action to perform on the database:" +
                    "\n1. Create a new customer." +
                    "\n2. View customer information." +
                    "\n3. Update customer information." +
                    "\n4. Delete a customer." +
                    "\n5. View all customers in the database. (sorted alphabetically by last name)" +
                    "\n6. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        ReadCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        ViewAllAlphabetically();
                        break;
                    case "6":
                        isRunning = false;
                        Console.WriteLine("Goodbye.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid response.");
                        Console.ReadLine();
                        break;
                }
            }
        }


        /******** Menu Methods ******************************
         ****************************************************/

        private void CreateCustomer()
        {
            Customer newCustomer = new Customer
            {
                FirstName = FirstName(),
                LastName = LastName(),
                Type = Type()
            };
            newCustomer.Email = Email(newCustomer.Type);

            _customerRepo.AddCustomerToList(newCustomer);
        }

        private void ReadCustomer()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();
            int result = SearchDatabase();
            if (result == -1)
            {
                Console.WriteLine("No customer found with this last name.");
            }
            else
            {
                Console.WriteLine($"First name: {customerList[result].FirstName}" +
                    $"\nLast name: {customerList[result].LastName}" +
                    $"\nType: {customerList[result].Type}" +
                    $"\nEmail: {customerList[result].Email}");
            }
        }

        private void UpdateCustomer()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();
            int result = SearchDatabase();
            if (result == -1)
            {
                Console.WriteLine("No customer found with this last name.");
            }
            else
            {
                string updateCandidate = customerList[result].FirstName + " " + customerList[result].LastName;
                Console.WriteLine("Do you want to update " + updateCandidate + "? ('yes' or 'no')");
                string updateAnswer = Console.ReadLine();
                if (updateAnswer == "yes")
                {
                    customerList.RemoveAt(result);
                    CreateCustomer();
                }
                else
                {
                    Console.WriteLine("No action taken.");
                }
            }
        }

        private void DeleteCustomer()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();
            int result = SearchDatabase();
            if (result == -1)
            {
                Console.WriteLine("No customer found with this last name.");
            }
            else
            {
                string removalCandidate = customerList[result].FirstName + " " + customerList[result].LastName;
                Console.WriteLine("Do you want to remove " + removalCandidate + "? ('yes' or 'no')");
                string removalAnswer = Console.ReadLine();
                if (removalAnswer == "yes")
                {
                    customerList.RemoveAt(result);
                    Console.WriteLine(removalCandidate + " has been removed.");
                }
                else
                {
                    Console.WriteLine("No action taken");
                }
            }
        }

        private void ViewAllAlphabetically()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();

            var sortedList =
                from customer in customerList
                orderby customer.LastName, customer.FirstName
                select new { customer.FirstName, customer.LastName, customer.Type, customer.Email };

            Console.WriteLine("FirstName  LastName  Type             Email");
            foreach (var item in sortedList)
            {
                Console.WriteLine("{0}    {1}    {2}            {3}", item.FirstName, item.LastName, item.Type, item.Email);
            }
        }

        /****************************************************
         ****************************************************/

        /******** Data Altering Methods *********************
         ****************************************************/

        private string FirstName()
        {
            Console.WriteLine("What is the customer's first name?");
            return Console.ReadLine();
        }

        private string LastName()
        {
            Console.WriteLine("What is the customer's last name?");
            return Console.ReadLine();
        }

        private string Type()
        {
            string type;
            bool isValidCustomerType;           
            do
            {
                Console.WriteLine("What is the customer's type? ('Potential', 'Current', or 'Past')");
                type = Console.ReadLine();
                if (type == "Potential" || type == "Current" || type == "Past")
                {
                    isValidCustomerType = true;
                }
                else
                {
                    isValidCustomerType = false;
                    Console.WriteLine("Invalid Type.");
                }
            } while (isValidCustomerType == false);
            return type;
        }

        private string Email(string type)
        {
            switch (type)
            {
                case "Potential":
                    return "We currently have the lowest rates on Helicopter Insurance!";
                case "Current":
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                case "Past":
                    return "It's been a long time since we've heard from you, we want you back";
                default:
                    return "Unexpected Error";
            }
        }

        /****************************************************
         ****************************************************/

        private int SearchDatabase()
        {
            List<Customer> customerList = _customerRepo.GetCustomerList();

            Console.WriteLine("Please enter the last name of the customer you are searching for.");
            string searchInput = Console.ReadLine();

            foreach (Customer customer in customerList)
            {
                if(searchInput == customer.LastName)
                {
                    return customerList.IndexOf(customer);
                }
            }
            return -1;
        }
    }
}
