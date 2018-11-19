using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class Car
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public double GasMileage { get; set; }

        public Car(string type, string model, decimal price, double gasMileage)
        {
            Type = type;
            Model = model;
            Price = price;
            GasMileage = gasMileage;
        }

        public Car()
        {

        }
    }
}
