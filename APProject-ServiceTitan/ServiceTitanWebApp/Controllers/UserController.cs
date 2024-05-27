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
using ServiceTitanWebApp.ViewModels;


namespace ServiceTitanWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ServiceTitanDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;

        public UserController(ServiceTitanDBContext context, UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore)
        {
            _context = context;
            //_userManager = new UserManager<IdentityUser>();
            //_userStore = new IUserStore<IdentityUser>();
            //_emailStore = new IUserEmailStore<IdentityUser>();
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var serviceTitanDBContext = _context.Users.Include(u => u.Role);
            return View(await serviceTitanDBContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.UserRoles.Where(ur => ur.RoleID != 1), "RoleID", "RoleName");
            var viewModel = new NewUserViewModel
            {
                NewUser = new ApplicationUser(),
                Categories = _context.Categories,
                Services = _context.Services,
                AssignedServicesIds = new List<int>()
            };
            return View(viewModel);
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewUserViewModel userVM)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(userVM.NewUser);
                _context.SaveChanges();

                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, userVM.NewUser.UserEmail, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, userVM.NewUser.UserEmail, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, "Test@123");

                if (userVM.NewUser.RoleId == 3)
                {
                    ServiceTechnician st = new ServiceTechnician();
                    st.TechniciansId = userVM.NewUser.UserID;
                    foreach (int assignedServiceId in userVM.AssignedServicesIds)
                    {
                        st.ServicesId = assignedServiceId;   
                        _context.ServiceTechnicians.Add(st);
                        _context.SaveChanges();
                    }
                }
                TempData["CreateSuccess"] = "User Added Successfully";

                return RedirectToAction(nameof(Index));
            } else
            {
                var viewModel = new NewUserViewModel
                {
                    NewUser = userVM.NewUser,
                    Categories = _context.Categories,
                    Services = _context.Services,
                    CategoryId = userVM.CategoryId,
                    AssignedServicesIds = userVM.AssignedServicesIds
                };
                ViewData["RoleId"] = new SelectList(_context.UserRoles.Where(ur => ur.RoleID != 1), "RoleID", "RoleName", userVM.NewUser.RoleId);
                return View(viewModel);
            }
            //ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleID", "RoleName", user.RoleId);
            //return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleID", "RoleName", user.RoleId);

            var viewModel = new NewUserViewModel
            {
                NewUser = user,
                Categories = _context.Categories,
                Services = _context.Services,
            };

            return View(viewModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewUserViewModel userVM)
        {
            if (id != userVM.NewUser.UserID)
            {
                return NotFound();
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(userVM.NewUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userVM.NewUser.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["EditSuccess"] = "User Edited Successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleID", "RoleName", userVM.NewUser.RoleId);
            var viewModel = new NewUserViewModel
            {
                NewUser = userVM.NewUser,
                Categories = _context.Categories,
                Services = _context.Services,
                
            };
            return View(viewModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            TempData["DeleteSuccess"] = "User Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.UserID == id)).GetValueOrDefault();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
