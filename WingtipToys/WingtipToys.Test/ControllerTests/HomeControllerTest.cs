using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingtipToys.BLL.Interfaces.IServices;
using WingtipToys.BLL.Services;
using WingtipToys.Test.Fakes;
using WingtipToys.UI.Controllers;
using WingtipToys.UI.Models;
using Xunit;

namespace WingtipToys.Test.ControllerTests
{

    public class HomeControllerTest
    {
        [Fact]
        public void GetIndexTest()
        {
            var factory = new RepositoryFactoryFake();

            IProductService productService = new ProductService(factory.GetCategoryRepo(), factory.GetProductRepo());
            var logger = LoggerFactory.Create(x => x.AddConsole()).CreateLogger<HomeController>();
            var controller = new HomeController(productService, logger);
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(
                        viewResult.ViewData.Model);



            Assert.Equal(2, model.Products.Count);

        }
    }
}
