using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        MenuRepository _menuItemRepo = new MenuRepository();

        public void Run()
        {
            _menuItemRepo.CreateBasicMenu();
            RunManagerMenu();
        }

        private void RunManagerMenu()
        {
            Console.WriteLine("Welcome Komodo Cafe Manager.");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nChoose an action:" +
                    "\n1. Add a new menu item." +
                    "\n2. Delete a menu item." +
                    "\n3. View all current menu items." +
                    "\n4. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ViewAll();
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


        /******** Menu Methods ******************************
         ****************************************************/

        private void AddMenuItem()
        {
            MenuItem newMenuItem = new MenuItem
            {
                Number = MenuItemNumber(),
                Name = MenuItemName(),
                Description = MenuItemDescription(),
                Price = MenuItemPrice(),
                Ingredients = MenuItemIngredients()
            }; 
            _menuItemRepo.AddMenuItemToList(newMenuItem);
        }
            

            

        
        private void DeleteMenuItem()
        {
            List<MenuItem> menuItemList = _menuItemRepo.GetMenuItemList();
            Console.WriteLine("What menu item number do you want to delete?");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                int searchIndex = SearchMenu(result);
                if (searchIndex == -1)
                {
                    Console.WriteLine("Menu item not found.");
                }
                else
                {
                    Console.WriteLine("Do you want to remove menu item #" + menuItemList[searchIndex].Number + "? ('yes' or 'no')");
                    if (Console.ReadLine() == "yes")
                    {
                        Console.WriteLine("Menu item #" + menuItemList[searchIndex].Number + " has been removed.");
                        menuItemList.RemoveAt(searchIndex);
                    }
                    else
                    {
                        Console.WriteLine("No action taken.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Menu item not found.");
            }
               
        }

        private void ViewAll()
        {
            List<MenuItem> menuItemList = _menuItemRepo.GetMenuItemList();

            var sortedList =
                from menuitem in menuItemList
                orderby menuitem.Number
                select new { menuitem.Number, menuitem.Name, menuitem.Description, menuitem.Ingredients, menuitem.Price};

            Console.WriteLine("Number Name Description Price \n Ingredients");
            foreach (var item in sortedList)
            {
                Console.WriteLine("\n{0}    {1}    {2}    {3}", item.Number, item.Name, item.Description, item.Price.ToString("$0.00"));
                Console.Write("   Ingredients: ");
                int countForIngredientComma = item.Ingredients.Count();
                int i = 1;
                foreach (string ingredient in item.Ingredients)
                {
                    if(i < countForIngredientComma)
                    {
                        Console.Write(ingredient + ", ");
                        i++;
                    }
                    else
                    {
                        Console.Write(ingredient);
                    }
                }
            }
        }

        /****************************************************
         ****************************************************/

        /******** Data Altering Methods *********************
         ****************************************************/

        private int MenuItemNumber()
        {
            int result;
            bool isValid;
            do
            {
                Console.WriteLine("What is the number for this menu item?");
                string numberAsString = Console.ReadLine();
                if (int.TryParse(numberAsString, out result))
                {
                    if(result > 0)
                    {
                        if(SearchMenu(result) == -1)
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
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("Invalid entry. Please try again.");
                }

            } while (isValid == false);
            return result;
        }

        private string MenuItemName()
        {
            Console.WriteLine("What is the name of this menu item?");
            return Console.ReadLine();
        }

        private string MenuItemDescription()
        {
            Console.WriteLine("Please enter a description for this menu item.");
            return Console.ReadLine();
        }

        private decimal MenuItemPrice()
        {
            decimal result;
            bool isValid;
            do
            {
                Console.WriteLine("What will be the price of this menu item? " +
                    "(Please enter a number with up to 2 decimal places. Do not enter a dollar sign.)");
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

        private List<string> MenuItemIngredients()
        {
            List<string> ingredientList = new List<string>();
            bool moreIngredientsToAdd = true;
            while (moreIngredientsToAdd)
            {
                Console.WriteLine("Please enter an ingredient.");
                ingredientList.Add(Console.ReadLine());
     
                Console.WriteLine("Do you wish to add another ingredient? ('yes' or 'no')");
                if(Console.ReadLine() != "yes")
                {
                    moreIngredientsToAdd = false;
                }
            }
            return ingredientList;
        }

        /************************************************************************/

        private int SearchMenu(int searchInput)
        {
            List<MenuItem> menuItemList = _menuItemRepo.GetMenuItemList();

            foreach (MenuItem menuItem in menuItemList)
            {
                if (searchInput == menuItem.Number)
                {
                    return menuItemList.IndexOf(menuItem);
                }
            }
            return -1;
        }
    }
}
