using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();

        public void Run()
        {
            _outingRepo.CreateBasicOutings();
            RunAccountantMenu();
        }

        private void RunAccountantMenu()
        {
            Console.WriteLine("Welcome Komodo Outings Accountant.");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nChoose an action:" +
                    "\n1. View all Outings." +
                    "\n2. Add an Outing." +
                    "\n3. View Costs." +
                    "\n4. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        ViewAll();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        ViewCosts();
                        break;
                    case "4":
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

        private void ViewAll()
        {
            List<Outing> outingList = _outingRepo.GetOutingList();
            Console.WriteLine("Type     Attendance     Date     Cost per Person    Total Cost");
            foreach (var item in outingList)
            {
                Console.WriteLine(item);
            }
        }

        private void AddOuting()
        {
            string type = GetType();
            int attendance = GetAttendance();
            string date = GetDate();
            Outing newOuting = new Outing(type, attendance, date);
            _outingRepo.AddOutingToList(newOuting);
        }

        private void ViewCosts()
        {
            List<Outing> outingList = _outingRepo.GetOutingList();
            decimal golfCosts = 0;
            decimal bowlingCosts = 0;
            decimal amusementParkCosts = 0;
            decimal concertCosts = 0;
            decimal combinedCosts = 0;

            foreach (var item in outingList)
            {
                decimal cost = item.TotalCost;
                combinedCosts += cost;
                switch (item.Type)
                {
                    case "Golf":
                        golfCosts += cost;
                        break;
                    case "Bowling":
                        bowlingCosts += cost;
                        break;
                    case "Amusement Park":
                        amusementParkCosts += cost;
                        break;
                    case "Concert":
                        concertCosts += cost;
                        break;
                }

            }
            Console.WriteLine("The cost of all golf outings was: {0}", golfCosts.ToString("$0,000"));
            Console.WriteLine("The cost of all bowling outings was: {0}", bowlingCosts.ToString("$0,000"));
            Console.WriteLine("The cost of all amusement park outings was: {0}", amusementParkCosts.ToString("$0,000"));
            Console.WriteLine("The cost of all concert outings was: {0}", concertCosts.ToString("$0,000"));
            Console.WriteLine("\nThe combined cost of all outings was: {0}", combinedCosts.ToString("$0,000"));
        }

        /*****************************************************************/

        private string GetType()
        {
            string type;
            bool isValidOutingType;
            do
            {
                Console.WriteLine("What is the outing type? ('Golf', 'Bowling', 'Amusement Park' or 'Concert')");
                type = Console.ReadLine();
                if (type == "Golf" || type == "Bowling" || type == "Amusement Park" || type == "Concert")
                {
                    isValidOutingType = true;
                }
                else
                {
                    isValidOutingType = false;
                    Console.WriteLine("Invalid Type.");
                }
            } while (isValidOutingType == false);
            return type;
        }

        private int GetAttendance()
        {
            int result;
            bool isValid;
            do
            {
                Console.WriteLine("What was the attendance for this outing?");
                string numberAsString = Console.ReadLine();
                if (int.TryParse(numberAsString, out result))
                {
                    if (result > 0)
                    {
                            isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        Console.WriteLine("Invalid entry. Please try again.");
                    }
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("Invalid entry. Please try again.");
                }

            } while (isValid == false);
            return result;
        }

        private string GetDate()
        {
            Console.WriteLine("What was the date for this outing? Please enter in 'mm/dd/yyyy' format." +
                "\n   Note to code checkers - there is no error handling here. The format is just a preference.");
            return Console.ReadLine();
        }
    }
}
