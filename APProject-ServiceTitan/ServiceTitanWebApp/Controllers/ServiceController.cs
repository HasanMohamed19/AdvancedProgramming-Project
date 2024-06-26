using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.Helpers;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    public class ServiceController : BaseController
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

            if (!String.IsNullOrEmpty(searchName))
                searchName = searchName.ToLower();

            services = _context.Services
                .Include(s => s.ServiceTechnicians)
                .Include(c => c.Category)
                .ThenInclude(m => m.CategoryManager);

            // search for service name
            if (!String.IsNullOrEmpty(searchName))
            {
                services = services.Where(s => s.ServiceName!.ToLower().Contains(searchName)
                        || s.ServiceDescription.ToLower().Contains(searchName)
                        || s.Category.CategoryName.ToLower().Contains(searchName));
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
                ServiceTechnicians = _context.ServiceTechnicians,
            };

            if (User.IsInRole("Manager"))
            {
                TempData["userId"] = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            }

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
                .ThenInclude(m => m.CategoryManager)
                .FirstOrDefault(m => m.ServiceID == id);
            if (service == null)
            {
                return NotFound();
            }

            var servicesTechs = _context.ServiceTechnicians.Where(st => st.ServicesId == service.ServiceID).ToList();
            var technicians = new List<ApplicationUser>();
            foreach (var st in servicesTechs)
            {
                technicians.Add(_context.Users.Single(u => u.UserID == st.TechniciansId));
            }

            var detailsVM = new ServiceDetailsViewModel
            {
                Service = service,
                Technicians = technicians
            };

            return View(detailsVM);
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
                    Technicians = new MultiSelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", null),
                    Categories = _context.Categories.Where(m => m.CategoryManagerId == userID)
                };

                if (viewModel.Categories.Count() < 1 || viewModel.Categories == null)
                {
                    return View("NoCategory");
                }

                return View(viewModel);
            } else
            {
                var viewModel = new NewServiceViewModel
                {
                    Service = new(),
                    Technicians = new MultiSelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", null),
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
        public async Task<IActionResult> Create(NewServiceViewModel newService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newService.Service);
                await _context.SaveAsync(User, GetSourceRoute(), null);

                ServiceTechnician st = new ServiceTechnician();
                st.ServicesId = newService.Service.ServiceID;

                if (newService.TechniciansId == null)
                    newService.TechniciansId = new();

                foreach (var item in newService.TechniciansId)
                {
                    try
                    {
                        st.TechniciansId = item;
                        _context.ServiceTechnicians.Add(st);
                        _context.Save(User, GetSourceRoute(), null);
                        TempData["CreateSuccess"] = "Service Created Successfully";
                    } catch (Exception ex)
                    {
                        _context.LogException(ex, User, GetSourceRoute());
                        TempData["CreateFailed"] = "Could not create service.";
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            IQueryable<Category> categories;
            if (User.IsInRole("Admin"))
            {
                categories = _context.Categories;
            }
            else
            {
                int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                categories = _context.Categories.Where(m => m.CategoryManagerId == userID);
            }
            var viewModel = new NewServiceViewModel
            {
                Service = new(),
                Technicians = new MultiSelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", null),
                Categories = categories
            };
            return View(viewModel);

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
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", service.CategoryId);

            // dont allow wrong manager to edit
            ApplicationUser loggedInUser = _context.Users.Include(u => u.Role).Include(u => u.Category).Single(u => u.UserEmail == User.Identity.Name);
            if (User.IsInRole("Manager") && (loggedInUser.Category == null || (loggedInUser.Category != null && loggedInUser.Category.CategoryID != service.CategoryId)))
            {
                return Forbid();
            }

            IQueryable<Category> categories;
            if (User.IsInRole("Admin"))
            {
                categories = _context.Categories;
            }
            else
            {
                int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                categories = _context.Categories.Where(m => m.CategoryManagerId == userID);
            }

            var selectedTechnicians = _context.ServiceTechnicians.Where(u => u.ServicesId == service.ServiceID);
            List<int> techIds = new List<int>();
            foreach (var st in selectedTechnicians)
            {
                techIds.Add(st.TechniciansId);
            }

            var viewModel = new NewServiceViewModel
            {
                Service = service,
                Technicians = new MultiSelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", techIds),
                Categories = categories
            };
            return View(viewModel);


        }

        [Authorize(Roles = "Admin,Manager")]
        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Service,TechniciansId")] NewServiceViewModel serviceVM)
        {
            if (id != serviceVM.Service.ServiceID)
            {
                return NotFound();
            }

            if (User.IsInRole("Manager"))
            {
                int managerId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                serviceVM.Service.CategoryId = _context.Categories.Single(u => u.CategoryManagerId == managerId).CategoryID;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // loop through all technicians in the db and check which 
                    // have been modified for this service
                    var technicians = _context.Users.Where(u => u.RoleId == 3).ToList();
                    for (int i=0; i<technicians.Count(); i++)
                    {
                        ApplicationUser tech = technicians[i];
                        bool relationshipExists = _context.ServiceTechnicians
                            .Any(st => st.TechniciansId == tech.UserID
                            && st.ServicesId == serviceVM.Service.ServiceID);

                        if (serviceVM.TechniciansId == null)
                            serviceVM.TechniciansId = new();

                        if (!relationshipExists && serviceVM.TechniciansId.Any(t => t == tech.UserID))
                        {
                            // add if not already selected
                            _context.ServiceTechnicians.Add(new ServiceTechnician { 
                                TechniciansId = tech.UserID, ServicesId = id });
                        } else if (relationshipExists && !serviceVM.TechniciansId.Any(t => t == tech.UserID))
                        {
                            // remove if deselected
                            _context.ServiceTechnicians.Remove(_context.ServiceTechnicians
                                .Single(st => st.TechniciansId == tech.UserID && st.ServicesId == id)
                                );
                        }
                    }
                    _context.Update(serviceVM.Service);

                    await _context.SaveAsync(User, GetSourceRoute(), null);
                    TempData["EditSuccess"] = "Service Edited Successfully";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ServiceExists(serviceVM.Service.ServiceID))
                    {
                        return NotFound();
                    }
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["EditFailed"] = "Could not save service.";
                } catch (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["EditFailed"] = "Could not save service.";
                }
                return RedirectToAction(nameof(Index));
            }

            IQueryable<Category> categories;
            if (User.IsInRole("Manager"))
            {
                categories = _context.Categories;
            }
            else
            {
                int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                categories = _context.Categories.Where(m => m.CategoryManagerId == userID);
            }
            var selectedTechnicians = _context.ServiceTechnicians.Where(u => u.ServicesId == serviceVM.Service.ServiceID);
            List<int> techIds = new List<int>();
            foreach (var st in selectedTechnicians)
            {
                techIds.Add(st.TechniciansId);
            }

            var viewModel = new NewServiceViewModel
            {
                Service = serviceVM.Service,
                Technicians = new MultiSelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", techIds),
                Categories = categories
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = _context.Services
                .Include(s => s.Category)
                .ThenInclude(m => m.CategoryManager)
                .FirstOrDefault(m => m.ServiceID == id);
            if (service == null)
            {
                return NotFound();
            }

            // forbid wrong manager from deleting
            ApplicationUser loggedInUser = _context.Users.Include(u => u.Role).Include(u => u.Category).Single(u => u.UserEmail == User.Identity.Name);
            if (User.IsInRole("Manager") && (loggedInUser.Category == null || (loggedInUser.Category != null && loggedInUser.Category.CategoryID != service.CategoryId)))
            {
                return Forbid();
            }

            var servicesTechs = _context.ServiceTechnicians.Where(st => st.ServicesId == service.ServiceID).ToList();
            var technicians = new List<ApplicationUser>();
            foreach (var st in servicesTechs)
            {
                technicians.Add(_context.Users.Single(u => u.UserID == st.TechniciansId));
            }

            var detailsVM = new ServiceDetailsViewModel
            {
                Service = service,
                Technicians = technicians
            };

            return View(detailsVM);
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
            var hasAnyRequestsInProgressOrPending = _context.ServiceRequests.Where(sr => sr.ServiceId == service.ServiceID && (sr.StatusId == 1 || sr.StatusId == 2)).ToList();
            if (hasAnyRequestsInProgressOrPending.Count() != 0)
            {
                // return alert
                TempData["cannotDelete"] = "<script>alert('Cannot delete service becuase there are pending/inprogress requests for it.');</script>";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                if (service != null)
                {
                    _context.Services.Remove(service);
                }

                await _context.SaveAsync(User, GetSourceRoute(), null);
                TempData["DeleteSuccess"] = "Service Deleted Successfully";
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
                TempData["DeleteFailed"] = "Could not delete service.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Services?.Any(e => e.ServiceID == id)).GetValueOrDefault();
        }
    }
}
