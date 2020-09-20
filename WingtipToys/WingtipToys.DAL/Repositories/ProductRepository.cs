using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using WingtipToys.BLL.Interfaces.IRepositories;
using WingtipToys.BLL.Models;


namespace WingtipToys.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private WingtipToysContext _wingtipToysDbContext;

        public ProductRepository(WingtipToysContext wingtipToysDbContext)
        {
            this._wingtipToysDbContext = wingtipToysDbContext;
        }

        public List<Product> GetProducts()
        {
            var products = _wingtipToysDbContext.Products.ToList();
            return products;
        }

        public List<Product> GetProducts(Category productCategory)
        {
            var products = _wingtipToysDbContext.Products.Where(x => x.CategoryId == productCategory.CategoryId).ToList();
            return products;
        }
    }
}
