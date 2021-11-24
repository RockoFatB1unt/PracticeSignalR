using DiAndSignalRApp.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace DiAndSignalRApp.Hubs
{
    public class PushNotificationHub : Hub
    {
        private readonly IAppDbContext _context;

        public PushNotificationHub(IAppDbContext context)
        {
            _context = context;
        }
        public async Task SendNotification()
        {
            var count = _context.Products.Count();
            await Clients.All.SendAsync("ReceiveNotification", "Current stock is " + count);
        }
    }
}
