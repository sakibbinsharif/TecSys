using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Models;

namespace WingtipToys.BLL.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Product> GetProducts(Category productCategory);
    }
}
