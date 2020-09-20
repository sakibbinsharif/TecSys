using System;
using System.Collections.Generic;
using System.Text;
using WingtipToys.BLL.Models;

namespace WingtipToys.BLL.Interfaces.IServices
{
    public interface IProductService
    {
        public List<Product> GetCars();
    }
}
