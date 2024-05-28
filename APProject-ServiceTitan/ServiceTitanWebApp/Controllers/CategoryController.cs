using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ServiceTitanDBContext _context;

        public CategoryController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Category
        public IActionResult Index(string searchName, string searchManager)
        {
            //IQueryable<Category> categories = _context.Categories.Include(c => c.CategoryManager);
            IEnumerable<Category> categories;
            if (!String.IsNullOrEmpty(searchName))
                searchName = searchName.ToLower();

            // if no filter is used
            categories = _context.Categories
                .Include(c => c.CategoryManager);

            // search for category name or description
            if (!String.IsNullOrEmpty(searchName))
            {
                categories = categories.Where(c => c.CategoryName!.ToLower().Contains(searchName)
                || (c.CategoryDescription != null && c.CategoryDescription.ToLower().Contains(searchName)));
            }

            // search for manager
            if (!String.IsNullOrEmpty(searchManager))
            {
                categories = categories.Where(c => c.CategoryManagerId == Convert.ToInt32(searchManager));
            }

            var categoryIndexVM = new CategoryIndexViewModel
            {
                Categories = categories,
                Managers = _context.Users.Where(u => u.RoleId == 2)
            };

            //var managers = new SelectList(_context.Users.Where(u => u.RoleId == 2), "UserID", "FullName", searchManager);
            //ViewBag.managers = managers;

            return View(categoryIndexVM);
        }

        [Authorize]
        // GET: Category/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = _context.Categories
                .Include(c => c.CategoryManager)
                .FirstOrDefault(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize(Roles = "Admin")]
        // GET: Category/Create
        public IActionResult Create()
        {
            //ViewData["CategoryManagerId"] = new SelectList(_context.Users, "UserID", "UserName");
            var viewModel = new NewCategoryViewModel
            {
                Category = new(),
                Users = _context.Users.Where(u => u.RoleId == UserRole.GetRoleId("Manager") && (u.Category.CategoryManagerId == null || u.Category.CategoryManagerId == 0))
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewCategoryViewModel newCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCategory.Category);
                _context.SaveChanges();
                TempData["CreateSuccess"] = "Category Created Successfully";
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index");
            } else
            {
                var viewModel = new NewCategoryViewModel
                {
                    Category = newCategory.Category,
                    Users = _context.Users.Where(u => u.RoleId == UserRole.GetRoleId("Manager") && (u.Category.CategoryManagerId == null || u.Category.CategoryManagerId == 0))
                };
                return View(viewModel);
            }
            //ViewData["CategoryManagerId"] = new SelectList(_context.Users, "UserID", "UserName", category.CategoryManagerId);
            //return View(newCategory);
        }

        [Authorize(Roles = "Admin")]
        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new NewCategoryViewModel
            {
                Category = category,
                Users = _context.Users.Where(u => u.RoleId == UserRole.GetRoleId("Manager") && (u.Category.CategoryManagerId == null || u.Category.CategoryManagerId == 0))
            };

            //ViewData["CategoryManagerId"] = new SelectList(_context.Users, "UserID", "UserName", category.CategoryManagerId);
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NewCategoryViewModel editCategory)
        {
            if (id != editCategory.Category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editCategory.Category);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(editCategory.Category.CategoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["CreateSuccess"] = "Category Edited Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var viewModel = new NewCategoryViewModel
                {
                    Category = editCategory.Category,
                    Users = _context.Users.Where(u => u.RoleId == UserRole.GetRoleId("Manager") && (u.Category.CategoryManagerId == null || u.Category.CategoryManagerId == 0))
                };
                return View(viewModel);
            }
            //ViewData["CategoryManagerId"] = new SelectList(_context.Users, "UserID", "UserName", category.CategoryManagerId);
            //return View(category);
        }

        [Authorize(Roles = "Admin")]
        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = _context.Categories
                .Include(c => c.CategoryManager)
                .FirstOrDefault(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize(Roles = "Admin")]
        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Categories'  is null.");
            }
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            
            _context.SaveChanges();
            TempData["CreateSuccess"] = "Category Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (_context.Categories?.Any(e => e.CategoryID == id)).GetValueOrDefault();
        }

        public IActionResult getAllRequests()
        {
            try
            {
                var requestsByCategories = _context.Categories.Select(c => new
                {
                    name = c.CategoryName,
                    sales = _context.ServiceRequests.Include(s => s.Service).Where(sr => sr.Service.CategoryId == c.CategoryID).Sum(s=> s.RequestPrice)
                });

                return Json(requestsByCategories);
            } catch
            {
                return BadRequest();
            }
        }

        public IActionResult Dashboard()
        {

            if (User.IsInRole("Manager"))
            {
                int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                string topSellingService = _context.Services
                .Where(s => s.Category.CategoryManagerId == userID)
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault().ServiceName;

                string pendingRequests = _context.ServiceRequests
                .Where(sr => sr.StatusId == 2 && sr.Service.Category.CategoryManagerId == userID)
                .Count().ToString();

                ViewData["topSellingService"] = topSellingService;
                ViewData["pendingRequests"] = pendingRequests;
            }
            else
            {
                string topSellingService = _context.Services
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault().ServiceName;

                string pendingRequests = _context.ServiceRequests
                .Where(sr => sr.StatusId == 2)
                .Count().ToString();

                ViewData["topSellingService"] = topSellingService;
                ViewData["pendingRequests"] = pendingRequests;
            }



            return View("Dashboard");
        }
    }
}
