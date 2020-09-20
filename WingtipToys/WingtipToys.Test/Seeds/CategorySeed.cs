using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Models;

namespace WingtipToys.Test.Seeds
{
    class CategorySeed
    {
        public static Category CarCategory => new Category
        {
            CategoryId = 1,
            CategoryName = "TestCar",
            Description = "TestCarDescription"
        };
        public static Category BoatCategory => new Category
        {
            CategoryId = 2,
            CategoryName = "TestBoat",
            Description = "TestBoatDescription"
        };
    }
}
