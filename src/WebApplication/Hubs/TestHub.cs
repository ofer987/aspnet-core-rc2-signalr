using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace WebApplication.Hubs
{
    [HubName("test")]
    public class TestHub : Hub
    {
        public void Test() {
            Clients.Caller.invoke("Hello, World!");
        }
    }
}