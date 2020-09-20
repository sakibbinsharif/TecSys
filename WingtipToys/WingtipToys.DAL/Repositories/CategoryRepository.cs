using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingtipToys.BLL.Interfaces.IRepositories;
using WingtipToys.BLL.Models;

namespace WingtipToys.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private WingtipToysContext _wingtipToysDbContext;
        public CategoryRepository(WingtipToysContext wingtipToysDbContext)
        {
            this._wingtipToysDbContext = wingtipToysDbContext;
        }

        public Category GetCategory(Func<Category, bool> expression)
        {
            var category = _wingtipToysDbContext.Categories.Where(expression).SingleOrDefault();
            return category;
        }
    }
}
