using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InfotechVision.Models;
using InfotechVision.Models.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace InfotechVision.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly HostingEnvironment hostingEnvironment;
        private readonly string filePath;
        private bool IsSuperAdmin, IsAdmin;
        public EventsController(IUnitOfWork context, HostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this.hostingEnvironment = hostingEnvironment;
            this.filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", "events", "images");
        }

        public IActionResult Index()
        {
            this.IsSuperAdmin = User.IsInRole(RolesOfUser.SuperAdmin.ToString());
            this.IsAdmin = User.IsInRole(RolesOfUser.Admin.ToString());

            if (User.Identity.IsAuthenticated && IsSuperAdmin || IsAdmin)
                return View(_context.Events.GetEventsForAdmin());
            else
                return View(_context.Events.GetEventsForUser(User.Identity.Name));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                events.ContentDetail.Image = _context.News.FileUpload(events.ContentDetail.Upload, this.filePath, "Events", events.ContentDetail.Title);
                events.ContentDetail.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                events.ContentDetail.UpdatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                events.ContentDetail.CreatedDate = DateTime.Now;
                events.ContentDetail.UpdatedDate = DateTime.Now;

                _context.Events.Add(events);
                _context.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var Event=GetEventById(id);

            if (Event == null)
            {
                return NotFound();
            }
            
            return View(Event);
        }

        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var Event = GetEventById(id);

            if(Event==null)
            {
                return NotFound();
            }

            return View(Event);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var Event = _context.Events.GetEntityByID(id);
            Event.ContentDetail = _context.ContentDetail.GetEntityByID(Event.ContentID);
            _context.ContentDetail.RemoveFileByName(Path.Combine(this.filePath, Event.ContentDetail.Image));
            _context.ContentDetail.Remove(Event.ContentDetail);
            _context.Events.Remove(Event);
            _context.Complete();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var events = GetEventById(id);

            if(events==null)
            {
                return NotFound();
            }

            return View(events);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Event events)
        {
            if (id != events.EventID)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    if(events.ContentDetail.Upload!=null)
                    {
                        if(!String.IsNullOrEmpty(events.ContentDetail.Image))
                        {
                            _context.ContentDetail.RemoveFileByName(Path.Combine(this.filePath, events.ContentDetail.Image));
                        }
                        events.ContentDetail.Image = _context.Events.FileUpload(events.ContentDetail.Upload, this.filePath, "Events", events.ContentDetail.Title);
                    }
                    events.ContentDetail.UpdatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    events.ContentDetail.UpdatedDate = DateTime.Now;
                    if (events.Address!=null && events.EventType!=EventType.Conference.ToString())
                    {
                        _context.Address.Remove(events.Address);
                        events.AddressID = null;
                    }
                    if(events.EventType==EventType.OnDemand.ToString())
                    {
                        events.StartDate = null;
                        events.EndDate = null;
                    }
                    _context.Events.Update(events);
                    _context.Complete();
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        [NonAction]
        public Event GetEventById(int? Id)
        {
            this.IsSuperAdmin = User.IsInRole("SuperAdmin");
            this.IsAdmin = User.IsInRole("Admin");
            if (IsSuperAdmin || IsAdmin)
            {
                return _context.Events.GetEventsByIDForAdmin(Id);
            }
            else
            {
                return _context.Events.GetEventsByIDForUser(Id, User.Identity.Name);
            }
        }
    }
}