using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _listOfOutings = new List<Outing>();

        public void CreateBasicOutings()
        {
            Outing outing1 = new Outing("Golf", 35, "08/11/2018");
            Outing outing2 = new Outing("Bowling", 80, "07/12/2018");
            Outing outing3 = new Outing("Amusement Park", 46, "06/13/2018");
            Outing outing4 = new Outing("Concert", 14, "05/14/2018");
            Outing outing5 = new Outing("Golf", 100, "04/15/2018");
            Outing outing6 = new Outing("Bowling", 39, "03/16/2018");
            Outing outing7 = new Outing("Amusement Park", 20, "02/17/2018");
            Outing outing8 = new Outing("Concert", 25, "01/18/2018");
            AddOutingToList(outing1);
            AddOutingToList(outing2);
            AddOutingToList(outing3);
            AddOutingToList(outing4);
            AddOutingToList(outing5);
            AddOutingToList(outing6);
            AddOutingToList(outing7);
            AddOutingToList(outing8);
        }

        public void AddOutingToList(Outing outing)
        {
            _listOfOutings.Add(outing);
        }

        public List<Outing> GetOutingList()
        {
            return _listOfOutings;
        }
    }
}