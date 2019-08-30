using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfotechVision.Data;
using InfotechVision.Models;
using InfotechVision.Models.Repository;
using InfotechVision.Models.IRepository;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace InfotechVision.Controllers
{
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly HostingEnvironment hostingEnvironment;
        private readonly string filePath;
        private bool IsSuperAdmin, IsAdmin;

        public NewsController(IUnitOfWork context, HostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this.hostingEnvironment = hostingEnvironment;
            this.filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", "news", "images");
        }

        public IActionResult Index()
        {
            this.IsSuperAdmin = User.IsInRole("SuperAdmin");
            this.IsAdmin = User.IsInRole("Admin");

            if (User.Identity.IsAuthenticated && IsSuperAdmin || IsAdmin)
                return View(_context.News.GetNewsForAdmin());
            else
                return View(_context.News.GetNewsForUser(User.Identity.Name));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = GetNews(id);


            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.ContentDetail.Image = _context.News.FileUpload(news.ContentDetail.Upload, this.filePath, "News", news.ContentDetail.Title);
                news.ContentDetail.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                news.ContentDetail.UpdatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                news.ContentDetail.CreatedDate = DateTime.Now;
                news.ContentDetail.UpdatedDate = DateTime.Now;

                _context.News.Add(news);
                _context.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = GetNews(id);

            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, News news)
        {
            if (id != news.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (news.ContentDetail.Upload != null)
                    {
                        _context.ContentDetail.RemoveFileByName(Path.Combine(this.filePath, news.ContentDetail.Image));
                        news.ContentDetail.Image = _context.News.FileUpload(news.ContentDetail.Upload, this.filePath, "News", news.ContentDetail.Title);
                    }
                    news.ContentDetail.UpdatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    news.ContentDetail.UpdatedDate = DateTime.Now;
                    _context.News.Update(news);
                    _context.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = GetNews(id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var news = _context.News.GetEntityByID(id);
            var contentDetails = _context.ContentDetail.GetEntityByID(news.ContentID);
            _context.ContentDetail.RemoveFileByName(Path.Combine(this.filePath, news.ContentDetail.Image));
            _context.ContentDetail.Remove(contentDetails);
            _context.News.Remove(news);
            _context.Complete();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public News GetNews(int? Id)
        {
            this.IsSuperAdmin = User.IsInRole("SuperAdmin");
            this.IsAdmin = User.IsInRole("Admin");
            if (IsSuperAdmin || IsAdmin)
            {
                return _context.News.GetNewsByIDForAdmin(Id);
            }
            else
            {
                return _context.News.GetNewsByIDForUser(Id, User.Identity.Name);
            }
        }
    }
}
