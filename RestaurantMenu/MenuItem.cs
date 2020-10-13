using System;
namespace RestaurantMenu
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        private static int NextId = 1;
        private readonly int id;

        public MenuItem()
        {
            id = NextId;
            NextId++;
        }

        public int Id
        {
            get { return id; }
        }
    }
}
