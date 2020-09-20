using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Interfaces.IRepositories;
using WingtipToys.DAL.Repositories;

namespace WingtipToys.Test.Fakes
{
    public class RepositoryFactoryFake
    {

        public ICategoryRepository GetCategoryRepo()
        {
            var repo = new CategoryRepository(WingtipToysDbContextFactoryFake.GetDbContext());
            return repo;
        }
        public IProductRepository GetProductRepo()
        {
            var repo = new ProductRepository(WingtipToysDbContextFactoryFake.GetDbContext());
            return repo;
        }
    }
}
