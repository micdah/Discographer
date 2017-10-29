using System.Diagnostics;
using Discographer.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Discographer.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Discographer.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<HomeController>();
        private readonly DiscographerContext _context;

        public HomeController(DiscographerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationSettings = await _context.ApplicationSettings.SingleAsync();

            return View(new HomeModel
            {
                ApplicationSettingsId = applicationSettings.Id,
                DiscogsToken = applicationSettings.DiscogsToken
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
