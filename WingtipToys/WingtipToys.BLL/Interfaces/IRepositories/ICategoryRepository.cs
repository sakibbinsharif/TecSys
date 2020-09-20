using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Models;

namespace WingtipToys.BLL.Interfaces.IRepositories
{
    public interface ICategoryRepository
    {
        public Category GetCategory(Func<Category, bool> expression);
    }
}
