using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class ProgramUI
    {
        CarRepository _carRepo = new CarRepository();

        public void Run()
        {
            _carRepo.CreateBasicCars();
            RunAgentMenu();
        }

        private void RunAgentMenu()
        {
            Console.WriteLine("Welcome Komodo Insurance Agent.");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nChoose an action to perform on the database:" +
                    "\n1. Create a new car." +
                    "\n2. Review a particular car." +
                    "\n3. Update a particular car." +
                    "\n4. Delete a car." +
                    "\n5. View all cars of a particular type." +
                    "\n6. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        CreateCar();
                        break;
                    case "2":
                        ReviewCar();
                        break;
                    case "3":
                        UpdateCar();
                        break;
                    case "4":
                        DeleteCar();
                        break;
                    case "5":
                        ViewType();
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

        private void CreateCar()
        {
            Car newCar = new Car
            {
                Type = GetCarType(),
                Model = GetModel(),
                Price = GetPrice(),
                GasMileage = GetGasMileage()
            };
            _carRepo.AddCarToList(newCar);
        }

        private void ReviewCar()
        {
            List<Car> carList = _carRepo.GetCarList();
            int result = SearchDatabase();
            if (result == -1)
            {
                Console.WriteLine("Model not found.");
            }
            else
            {
                Console.WriteLine($"Type: {carList[result].Type}" +
                    $"\nModel: {carList[result].Model}" +
                    $"\nPrice: {carList[result].Price}" +
                    $"\nGas Mileage: {carList[result].GasMileage}");
            }
        }

        private void UpdateCar()
        {
            List<Car> carList = _carRepo.GetCarList();
            int result = SearchDatabase();
            if (result == -1)
            {
                Console.WriteLine("Model not found.");
            }
            else
            {
                string updateCandidate = carList[result].Model;
                Console.WriteLine("Do you want to update " + updateCandidate + "? ('yes' or 'no')");
                string updateAnswer = Console.ReadLine();
                if (updateAnswer == "yes")
                {
                    carList.RemoveAt(result);
                    CreateCar();
                }
                else
                {
                    Console.WriteLine("No action taken.");
                }
            }
        }

        private void DeleteCar()
        {
            List<Car> carList = _carRepo.GetCarList();
            int result = SearchDatabase();
            if (result == -1)
            {
                Console.WriteLine("Model not found.");
            }
            else
            {
                string removalCandidate = carList[result].Model;
                Console.WriteLine("Do you want to remove " + removalCandidate + "? ('yes' or 'no')");
                string removalAnswer = Console.ReadLine();
                if (removalAnswer == "yes")
                {
                    carList.RemoveAt(result);
                    Console.WriteLine(removalCandidate + " has been removed.");
                }
                else
                {
                    Console.WriteLine("No action taken");
                }
            }
        }

        private void ViewType()
        {
            

            List<Car> carList = _carRepo.GetCarList();
            string type;
            bool isValidCarType;
            do
            {
                Console.WriteLine("What car type do you want to see a list of? ('Electric', 'Hybrid', or 'Gas')");
                type = Console.ReadLine();
                if (type == "Electric" || type == "Hybrid" || type == "Gas")
                {
                    isValidCarType = true;

                    var carListSubset =
                        from car in carList
                        where car.Type == type
                        select new { car.Model, car.Price, car.GasMileage };

                    Console.WriteLine("\nModel       Price      Gas Mileage\n");
                    foreach (var car in carListSubset)
                    {
                        Console.WriteLine("{0}    {1}    {2}", car.Model, car.Price, car.GasMileage);
                    }
                }
                else
                {
                    isValidCarType = false;
                    Console.WriteLine("Invalid Type.");
                }
            } while (isValidCarType == false);
        }

        /****************************************************
         ****************************************************/

        /******** Data Altering Methods *********************
         ****************************************************/

        private string GetCarType()
        {
            string type;
            bool isValidCarType;
            do
            {
                Console.WriteLine("What is the car's type? ('Electric', 'Hybrid', or 'Gas')");
                type = Console.ReadLine();
                if (type == "Electric" || type == "Hybrid" || type == "Gas")
                {
                    isValidCarType = true;
                }
                else
                {
                    isValidCarType = false;
                    Console.WriteLine("Invalid Type.");
                }
            } while (isValidCarType == false);
            return type;
        }

        private string GetModel()
        {
            Console.WriteLine("What is the car's model?");
            return Console.ReadLine();
        }

        private decimal GetPrice()
        {
            decimal result;
            bool isValid;
            do
            {
                Console.WriteLine("What is the price of this car?");
                string numberAsString = Console.ReadLine();
                if (decimal.TryParse(numberAsString, out result))
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

        private double GetGasMileage()
        {
            double result;
            bool isValid;
            do
            {
                Console.WriteLine("What is the gas mileage of this car?");
                string numberAsString = Console.ReadLine();
                if (double.TryParse(numberAsString, out result))
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

        /****************************************************
         ****************************************************/

        private int SearchDatabase()
        {
            List<Car> carList = _carRepo.GetCarList();

            Console.WriteLine("Please enter the model of the car you are searching for.");
            string searchInput = Console.ReadLine();

            foreach (Car car in carList)
            {
                if (searchInput == car.Model)
                {
                    return carList.IndexOf(car);
                }
            }
            return -1;
        }
    }
}
