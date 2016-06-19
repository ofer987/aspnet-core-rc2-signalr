using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication.Hubs;

using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace WebApplication.Controllers
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
        [Authorize] 
        public IActionResult Poke()
        {
            TestHubContext.Clients.All.test($"Hello, World! ({++count})");
            return Json(null);
        }
    }
}
