using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Models;

namespace WingtipToys.Test.Seeds
{
    public class ProductSeed
    {
        public static Product RedCar =>
           new Product
           {
               ProductId = 101,
               CategoryId = 1,
               ProductName = "Red Car",
               UnitPrice = -100,
               Description = "Red car for test",
               ImagePath = "carfast.png"
           };
        public static Product BlueCar =>
           new Product
           {
               ProductId = 102,
               CategoryId = 1,
               ProductName = "Blue Car",
               UnitPrice = -100,
               Description = "Blue car for test",
               ImagePath = "carfast.png"
           };

        public static Product BigBoat =>
          new Product
          {
              ProductId = 201,
              CategoryId = 2,
              ProductName = "Big Boat",
              UnitPrice = -10,
              Description = "Big Boat for test",
              ImagePath = "boatpaper.png"
          };
        public static Product SmallBoat =>
           new Product
           {
               ProductId = 202,
               CategoryId = 2,
               ProductName = "Small Boat",
               UnitPrice = -20,
               Description = "Small Boat for test",
               ImagePath = "boatsail.png"
           };

    }
}
