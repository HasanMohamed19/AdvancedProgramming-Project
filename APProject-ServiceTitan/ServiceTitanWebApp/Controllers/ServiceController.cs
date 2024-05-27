using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceTitanDBContext _context;

        public ServiceController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Service
        public IActionResult Index(string searchName, string searchCategory)
        {

            IEnumerable<Service> services;

            services = _context.Services.Include(c => c.Category);

            // search for service name
            if (!String.IsNullOrEmpty(searchName))
            {
                services = services.Where(s => s.ServiceName!.Contains(searchName));
            }

            // filter by category
            if (!String.IsNullOrEmpty(searchCategory))
            {
                services = services.Where(s => s.CategoryId == Convert.ToInt32(searchCategory));
            }

            var serviceIndexVM = new ServiceIndexViewModel
            {
                Services = services,
                Categories = _context.Categories,
            };

            //var services = _context.Services.Include(s => s.Category);
            return View(serviceIndexVM);
        }

        [Authorize]
        // GET: Service/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = _context.Services
                .Include(s => s.Category)
                .FirstOrDefault(m => m.ServiceID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Service/Create
        public IActionResult Create()
        {
            if (User.IsInRole("Manager"))
            {
                int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                var viewModel = new NewServiceViewModel
                {
                    Service = new(),
                    Technicians = _context.Users.Where(u => u.RoleId == 3),
                    Categories = _context.Categories.Where(m => m.CategoryManagerId == userID)
                };
                return View(viewModel);
            } else
            {
                var viewModel = new NewServiceViewModel
                {
                    Service = new(),
                    Technicians = _context.Users.Where(u => u.RoleId == 3),
                    Categories = _context.Categories
                };
                return View(viewModel);
            }
            

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
           
        }

        [Authorize(Roles = "Admin,Manager")]
        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewServiceViewModel newService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newService.Service);
                _context.SaveChanges();
                TempData["CreateSuccess"] = "Service Created Successfully";
                return RedirectToAction(nameof(Index));
            } else
            {

                if (User.IsInRole("Manager"))
                {
                    int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                    var viewModel = new NewServiceViewModel
                    {
                        Service = new(),
                        Technicians = _context.Users.Where(u => u.RoleId == 3),
                        Categories = _context.Categories.Where(m => m.CategoryManagerId == userID)
                    };
                    return View(viewModel);
                } else
                {
                    var viewModel = new NewServiceViewModel
                    {
                        Service = new(),
                        Technicians = _context.Users.Where(u => u.RoleId == 3),
                        Categories = _context.Categories
                    };
                    return View(viewModel);
                }

                
            }
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", service.CategoryId);
            //return View(service);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", service.CategoryId);
            return View(service);
        }

        [Authorize(Roles = "Admin,Manager")]
        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceID,ServiceName,ServiceDescription,ServicePrice,CategoryId")] Service service)
        {
            if (id != service.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["EditSuccess"] = "Service Edited Successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", service.CategoryId);
            return View(service);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [Authorize(Roles = "Admin,Manager")]
        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Services'  is null.");
            }
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            TempData["DeleteSuccess"] = "Service Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Services?.Any(e => e.ServiceID == id)).GetValueOrDefault();
        }
    }
}
