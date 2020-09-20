using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Interfaces.IRepositories;
using WingtipToys.BLL.Interfaces.IServices;
using WingtipToys.BLL.Models;

namespace WingtipToys.BLL.Services
{
    public class ProductService : IProductService
    {
        private ICategoryRepository _categoryRepo;
        private IProductRepository _productRepo;

        public ProductService(ICategoryRepository categoryRepo, IProductRepository productRepo)
        {
            this._categoryRepo = categoryRepo;
            this._productRepo = productRepo;
        }
        public List<Product> GetCars()
        {
            var carCategory = _categoryRepo.GetCategory(x => x.CategoryId == 1);
            var cars = _productRepo.GetProducts(carCategory);
            return cars;
        }
    }
}
