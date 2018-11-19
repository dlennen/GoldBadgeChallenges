using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {
        List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        public void CreateBasicMenu()
        {

            MenuItem m1 = new MenuItem(1, "Hamburger", "Single-patty burger", 5.00m)
            {   Ingredients = new List<string>() { "bun", "patty", "condiments" }   };
            MenuItem m2 = new MenuItem(2, "Cheeseburger", "Single-patty burger with cheese", 5.25m)
            {   Ingredients = new List<string>() { "bun", "patty", "cheese", "condiments" }   };
            MenuItem m3 = new MenuItem(3, "Chicken Sandwich", "Breaded chicken breast sandwich", 5.00m)
            {   Ingredients = new List<string>() { "bun", "chicken breast", "pickles" }   };
            MenuItem m4 = new MenuItem(4, "Burrito", "Basic ground beef burrito", 6.00m)
            {   Ingredients = new List<string>() { "tortilla", "ground beef", "cheese", "rice" }   };
            MenuItem m5 = new MenuItem(5, "Fish Sandwich", "Breaded cod filet sandwich", 6.50m)
            {   Ingredients = new List<string>() { "bun", "cod filet", "tartar sauce" }   };
            MenuItem m6 = new MenuItem(6, "Chicken Fingers", "Three breaded chicken strips", 5.50m)
            { Ingredients = new List<string>() { "chicken breast", "dipping sauce" } };
            AddMenuItemToList(m1);
            AddMenuItemToList(m2);
            AddMenuItemToList(m3);
            AddMenuItemToList(m4);
            AddMenuItemToList(m5);
            AddMenuItemToList(m6);
        }

        public void AddMenuItemToList(MenuItem menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }

        public List<MenuItem> GetMenuItemList()
        {
            return _listOfMenuItems;
        }
    }
}
