using System.Diagnostics;
using Discographer.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Discographer.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<HomeController>();

        public IActionResult Index()
        {
            return View();
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
