using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using WebApplicationBasic.Hubs;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationBasic.Controllers
{
    public class TestController : Controller
    {
        public TestController(IHubContext<TestHub> testHubContext) 
        {
            TestHubContext = testHubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IHubContext<TestHub> TestHubContext {get; set; }

        static int count = 0;

        // GET: /<controller>/
        public IActionResult Poke()
        {
            TestHubContext.Clients.All.test($"Hello, World! ({++count})");
            return Json(null);
        }
    }
}
