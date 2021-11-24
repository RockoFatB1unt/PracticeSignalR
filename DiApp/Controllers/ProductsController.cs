using DiAndSignalRApp.Hubs;
using DiAndSignalRApp.Interfaces;
using DiAndSignalRApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DiAndSignalRApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAppDbContext _context;
        private readonly IHubContext<PushNotificationHub> _hub;
        public ProductsController(IAppDbContext context, IHubContext<PushNotificationHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChanges();
                await _hub.Clients.All.SendAsync("ReceiveNotification", product.Name + " added!");
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult AddProduct()
        {

            Product model = new Product();

            return PartialView("_AddProduct", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChanges();
                await _hub.Clients.All.SendAsync("ReceiveNotification", product.Name + " added!");
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
