using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly PruebaDbContext db;
        public HomeController(PruebaDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes= db.Cliente.ToList();
            ViewBag.clientes=clientes;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
