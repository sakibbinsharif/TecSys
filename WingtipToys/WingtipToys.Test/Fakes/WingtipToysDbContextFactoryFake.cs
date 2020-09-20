using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Models;
using WingtipToys.DAL;
using WingtipToys.Test.Seeds;

namespace WingtipToys.Test
{
    public class WingtipToysDbContextFactoryFake
    {
        private static WingtipToysContext DbContext;
        public static WingtipToysContext GetDbContext()
        {
            if (DbContext == null)
            {

                
                var options = new DbContextOptionsBuilder<WingtipToysContext>()
                            .UseInMemoryDatabase("wingtiptoys");

                var inMemoryDbContext = new WingtipToysContext(options.Options);

                var products = new List<Product>
                {
                    ProductSeed.RedCar,
                    ProductSeed.BlueCar,
                    ProductSeed.BigBoat,
                    ProductSeed.SmallBoat
                };

                var categories = new List<Category>
                {
                    CategorySeed.BoatCategory,
                    CategorySeed.CarCategory
                };

                inMemoryDbContext.AddRange(products);
                inMemoryDbContext.AddRange(categories);
                inMemoryDbContext.SaveChanges();


                DbContext = inMemoryDbContext;
            }
            return DbContext;


        }
    }
}
