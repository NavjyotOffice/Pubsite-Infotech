using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InfotechVision.Models;
using Microsoft.AspNetCore.Authorization;
using InfotechVision.Models.IRepository;
using InfotechVision.ViewModel;

namespace InfotechVision.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _context;
        public HomeController(IUnitOfWork context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
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
