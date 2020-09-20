using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingtipToys.BLL.Interfaces.IServices;
using WingtipToys.UI.Models;

namespace WingtipToys.UI.Controllers
{
    public class HomeController : BaseController
    {
        private IProductService _productService;

        public HomeController(
            IProductService productService,
            ILogger<HomeController> logger
            ) : base(logger)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {

            try
            {
                var viewModel = new HomeViewModel();
                viewModel.Products = _productService.GetCars();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw ex;
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
