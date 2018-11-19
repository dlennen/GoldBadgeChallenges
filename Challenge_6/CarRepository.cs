using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class CarRepository
    {
        List<Car> _listOfCars = new List<Car>();

        public void CreateBasicCars()
        {

            Car c1 = new Car("Electric", "Tesla", 77000m, 100d);
            Car c2 = new Car("Hybrid", "Prius", 23475m, 60d);
            Car c3 = new Car("Gas", "F-350", 30000m, 10d);
            Car c4 = new Car("Electric", "Soul", 33950m, 80d);
            Car c5 = new Car("Hybrid", "Fusion", 22215m, 50d);
            Car c6 = new Car("Gas", "Hummer", 40000m, 8d);
            AddCarToList(c1);
            AddCarToList(c2);
            AddCarToList(c3);
            AddCarToList(c4);
            AddCarToList(c5);
            AddCarToList(c6);
        }

        public void AddCarToList(Car car)
        {
            _listOfCars.Add(car);
        }

        public List<Car> GetCarList()
        {
            return _listOfCars;
        }
    }
}
