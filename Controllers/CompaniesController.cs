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
    public class CompaniesController : Controller
    {
        private readonly IUnitOfWork context;
        private readonly HostingEnvironment hostingEnvironment;
        private bool IsSuperAdmin, IsAdmin;
        private string filePath;

        public CompaniesController(IUnitOfWork context, HostingEnvironment hostingEnvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
            this.filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", "companies", "images");
        }

        public IActionResult Index()
        {
            this.IsSuperAdmin = User.IsInRole(RolesOfUser.SuperAdmin.ToString());
            this.IsAdmin = User.IsInRole(RolesOfUser.Admin.ToString());

            if (this.IsSuperAdmin || this.IsAdmin)
                return View(this.context.companies.GetCompanyForAdmin());
            else
                return View(this.context.companies.GetCompanyForUser(User.Identity.Name));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Company company)
        {
            if(ModelState.IsValid)
            {
                company.LogoImage = context.companies.FileUpload(company.Upload, filePath, "company", company.CompanyName);
                company.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                company.UpdatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                company.CreatedDate = DateTime.Now;
                company.UpdatedDate = DateTime.Now;

                this.context.companies.Add(company);
                this.context.Complete();
                return RedirectToAction(nameof(Index));

            }
            return View(company);
        }

        public IActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var company = GetCompanyById(id);

            if(company==null)
            {
                return NotFound();
            }

            return View(company);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int? id, Company company)
        {
            if (id != company.CompanyID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                company.UpdatedById = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                company.UpdatedDate = DateTime.Now;
                if (company.Upload != null)
                {
                    context.companies.RemoveFileByName(Path.Combine(filePath, company.LogoImage));
                    company.LogoImage = context.companies.FileUpload(company.Upload, filePath, "company", company.CompanyName);
                }
                this.context.companies.Update(company);
                this.context.Complete();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles ="SuperAdmin")]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = GetCompanyById(id);

            if (company == null)
            {
                NotFound();
            }

            context.companies.RemoveFileByName(Path.Combine(filePath, company.LogoImage));
            context.companies.Remove(company);
            context.Complete();

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public Company GetCompanyById(int? id)
        {
            this.IsSuperAdmin = User.IsInRole(RolesOfUser.SuperAdmin.ToString());
            this.IsAdmin = User.IsInRole(RolesOfUser.Admin.ToString());

            if (IsAdmin || IsSuperAdmin)
            {
                return this.context.companies.GetCompanyByIDForAdmin(id);
            }
            else
            {
                return this.context.companies.GetCompanyByIDForUser(id, User.Identity.Name);
            }
        }

    }
}