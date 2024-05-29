using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.Helpers;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ServiceTitanDBContext _context;

        public CategoryController(ServiceTitanDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            // add category manager id for dashboard
            if (User.IsInRole("Manager"))
            {
                int userId = _context.Users.Single(s => s.UserEmail == _userManager.GetUserName(User)).UserID;
                int? categoryId = _context.Categories.SingleOrDefault(c => c.CategoryManagerId != null && c.CategoryManagerId == userId)?.CategoryID;
                if (categoryId != null)
                    categoryIndexVM.ManagerCategoryId = categoryId;
            }

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
        public async Task<IActionResult> Create(NewCategoryViewModel newCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(newCategory.Category);
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                    TempData["CreateSuccess"] = "Category Created Successfully";

                } catch (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["CreateFailed"] = "Could not create category.";
                }
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
        public async Task<IActionResult> Edit(int id, NewCategoryViewModel editCategory)
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
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                    TempData["EditSuccess"] = "Category Saved Successfully";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CategoryExists(editCategory.Category.CategoryID))
                    {
                        return NotFound();
                    }
                    _context.LogException(ex, User, GetSourceRoute());
                }
                catch (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["EditFailed"] = "Could not save category.";
                }
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Categories'  is null.");
            }
            try
            {
                var category = _context.Categories.Find(id);

                var hasAnyServiceNotCompleted = _context.ServiceRequests
                .Include(sr => sr.Service)
                .ThenInclude(s => s.Category)
                .Where(x => x.Service.CategoryId == category.CategoryID && (x.StatusId == 1 || x.StatusId == 2)).ToList();

                if (hasAnyServiceNotCompleted.Count() != 0)
                {
                    // return alert
                    TempData["cannotDelete"] = "<script>alert('Cannot delete category becuase there are one or more requests for one or more of its services.');</script>";
                    return RedirectToAction(nameof(Index));
                }

                if (category != null)
                {
                    _context.Categories.Remove(category);
                }

                await _context.SaveAsync(User, GetSourceRoute(), null);
                TempData["DeleteSuccess"] = "Category Deleted Successfully";
            }
            catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
                TempData["DeleteFailed"] = "Could not delete category.";
            }
            
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

        public IActionResult Dashboard(int? categoryId)
        {
            if (categoryId == null && User.IsInRole("Admin"))
            {
                var topService = _context.Services
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault();
                string topSellingService = topService != null ? topService.ServiceName : "None";
                topSellingService ??= "";

                string pendingRequests = _context.ServiceRequests
                .Where(sr => sr.StatusId == 1)
                .Count().ToString();

                ViewData["topSellingService"] = topSellingService;
                ViewData["pendingRequests"] = pendingRequests;
            }

            if (categoryId != null && User.IsInRole("Manager"))
            {
                int userID = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;

                var topService = _context.Services
                .Where(s => s.CategoryId != null && s.CategoryId == categoryId)
                .OrderByDescending(service => service.ServiceRequests.Sum(sr => sr.RequestPrice))
                .FirstOrDefault();
                string topSellingService = topService != null ? topService.ServiceName : "None";
                topSellingService ??= "";

                string pendingRequests = _context.ServiceRequests
                .Where(sr => sr.StatusId == 1 && sr.Service.CategoryId == categoryId)
                .Count().ToString();
                pendingRequests ??= "";

                ViewData["topSellingService"] = topSellingService;
                ViewData["pendingRequests"] = pendingRequests;
            }

            return View("Dashboard");
        }
    }
}
