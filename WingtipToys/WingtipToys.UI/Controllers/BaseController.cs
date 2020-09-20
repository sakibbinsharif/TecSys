using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingtipToys.UI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger<HomeController> logger;
        public BaseController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
    }
}
