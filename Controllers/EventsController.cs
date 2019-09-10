using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfotechVision.Models;
using InfotechVision.Models.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InfotechVision.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _context;
        public EventsController(IUnitOfWork context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
            }
            return View();
        }
    }
}