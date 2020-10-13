using System;
using System.Collections.Generic;

namespace RestaurantMenu
{
    public class Restaurant
    {
        public static List<Menu> Menus = new List<Menu>() { };


        public Restaurant()
        {
        }

        public static void InitialPrompt()
        {
            Console.WriteLine("Welcome to Logan's Restaurant! Please choose a menu to view:\n0 - Create New Menu");
            foreach (Menu menu in Menus)
            {
                Console.WriteLine($"{menu.id} - {menu.Name}");
            }

            int input = GetChoice();

            if (input == 0)
            {
                Menu newMenu = new Menu();
                Console.WriteLine("What is the name of your new menu?");
                newMenu.Name = Console.ReadLine();
                Menus.Add(newMenu);
                Console.WriteLine($"You've created the {newMenu.Name} Menu!");
                MenuPrompt(newMenu);
            }
            else
            {
                foreach (Menu menu in Menus)
                {

                    if (input == menu.id)
                    {
                        Console.WriteLine($"\n*****\n{menu.Name}\n*****");
                        Console.WriteLine("\n*****\nAppetizers\n*****");
                        foreach (MenuItem menuItem in menu.MenuItems)
                        {
                            if (menuItem.Category == "Appetizer")
                            {
                                Console.WriteLine($"\n{menuItem.Name} - {menuItem.Price}\n{menuItem.Description}\n----------");
                            }
                        }
                        Console.WriteLine("Main Courses\n*****");
                        foreach (MenuItem menuItem in menu.MenuItems)
                        {
                            if (menuItem.Category == "Main Course")
                            {
                                Console.WriteLine($"\n{menuItem.Name} - {menuItem.Price}\n{menuItem.Description}\n----------");
                            }
                        }
                        Console.WriteLine("Desserts\n*****");
                        foreach (MenuItem menuItem in menu.MenuItems)
                        {
                            if (menuItem.Category == "Dessert")
                            {
                                Console.WriteLine($"\n{menuItem.Name} - {menuItem.Price}\n{menuItem.Description}\n----------");
                            }
                        }
                        InitialPrompt();
                    }
                }
            }
        }

        public static int GetChoice()
        {
            string input = Console.ReadLine();
            try
            {
                int i = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            int inputAsInt = Int32.Parse(input);

            return inputAsInt;
        }

        public static void MenuPrompt(Menu newMenu)
        {
            Console.WriteLine("What would you like to do?\n0 - Add new Menu Item\n1 - Go back");
            int choice = GetChoice();
            if (choice == 0)
            {
                MenuItem newMenuItem = new MenuItem();
                Console.WriteLine("What is the name of your new menu item?");
                newMenuItem.Name = Console.ReadLine();
                Console.WriteLine("What is the description of your new menu item?");
                newMenuItem.Description = Console.ReadLine();
                Console.WriteLine("Choose a category for your new menu item:\n0 - Appetizer\n1 - Main Course\n2 - Dessert");
                int categoryChoice = GetChoice();
                if (categoryChoice == 0)
                {
                    newMenuItem.Category = "Appetizer";
                }
                else if (categoryChoice == 1)
                {
                    newMenuItem.Category = "Main Course";
                }
                else
                {
                    newMenuItem.Category = "Dessert";
                }
                Console.WriteLine("What is the price for your new menu item?");
                newMenuItem.Price = Console.ReadLine();
                newMenu.MenuItems.Add(newMenuItem);
                Console.WriteLine($"You've successfully added {newMenuItem.Name} to {newMenu.Name}!");
                MenuPrompt(newMenu);
            }
            else 
            {
                InitialPrompt();
            }
        }

        public static void Main(string[] args)
        {
            InitialPrompt();  
        }
    }
}
