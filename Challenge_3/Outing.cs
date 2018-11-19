using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class Outing
    {
        public string Type { get; set; }
        public int Attendance { get; set; }
        public string Date { get; set; }
        public decimal CostPerPerson { get; }
        public decimal TotalCost { get; }

        public Outing(string type, int attendance, string date)
        {
            Type = type;
            Attendance = attendance;
            Date = date;
            switch (type)
            {
                case "Golf":
                    CostPerPerson = 40m;
                    break;
                case "Bowling":
                    CostPerPerson = 20m;
                    break;
                case "Amusement Park":
                    CostPerPerson = 35m;
                    break;
                case "Concert":
                    CostPerPerson = 50m;
                    break;
            }
            TotalCost = Attendance * CostPerPerson;
        }

        public override string ToString()
        {
            return Type + "   " + Attendance + "   " + Date + "   " + CostPerPerson.ToString("$0") + "   " + TotalCost.ToString("$0");
        }
    }
}
