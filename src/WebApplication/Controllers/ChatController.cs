using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication.Hubs;

// We want to use the AuthorizeAttribute from ASP.NET, not SignalR.
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace WebApplication.Controllers
{
    public class ChatController : Controller
    {
        public ChatController(IHubContext<ChatHub> chatHubContext) 
        {
            ChatHubContext = chatHubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IHubContext<ChatHub> ChatHubContext {get; set; }

        static int count = 0;

        // GET: /<controller>/
        [Authorize] 
        public IActionResult Poke()
        {
            ChatHubContext.Clients.All.poke("Hey!");
            return Json(null);
        }
    }
}
