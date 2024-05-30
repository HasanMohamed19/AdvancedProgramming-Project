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
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
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
            var serviceTitanDBContext = _context.Users.Include(u => u.Role).Where(r => r.RoleId != 1);
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
                Services = new MultiSelectList(_context.Services, "ServiceID", "ServiceName", null),
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
                _context.Save(User,GetSourceRoute(),null);

                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, userVM.NewUser.UserEmail, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, userVM.NewUser.UserEmail, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, "Test@123");

                if (userVM.NewUser.RoleId == 2)
                {
                    await _userManager.AddToRoleAsync(user, "Manager");
                } else if (userVM.NewUser.RoleId == 3)
                {
                    await _userManager.AddToRoleAsync(user, "Technician");
                } else if (userVM.NewUser.RoleId == 4)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                

                userVM.AssignedServicesIds ??= new List<int>();

                if (userVM.NewUser.RoleId == 3)
                {
                    ServiceTechnician st = new ServiceTechnician();
                    st.TechniciansId = userVM.NewUser.UserID;
                    foreach (int assignedServiceId in userVM.AssignedServicesIds)
                    {
                        try
                        {
                            st.ServicesId = assignedServiceId;   
                            _context.ServiceTechnicians.Add(st);
                            _context.Save(User, GetSourceRoute(), null);
                            TempData["CreateSuccess"] = "User Added Successfully";  

                        } catch (Exception ex)
                        {
                            _context.LogException(ex, User, GetSourceRoute());
                            TempData["CreateFailed"] = "Could not add user.";
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            var viewModel = new NewUserViewModel
            {
                NewUser = userVM.NewUser,
                Categories = _context.Categories,
                Services = new MultiSelectList(_context.Services, "ServiceID", "ServiceName", null),
                CategoryId = userVM.CategoryId,
                AssignedServicesIds = userVM.AssignedServicesIds
            };
            ViewData["RoleId"] = new SelectList(_context.UserRoles.Where(ur => ur.RoleID != 1), "RoleID", "RoleName", userVM.NewUser.RoleId);
            return View(viewModel);


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
            ViewData["RoleId"] = new SelectList(_context.UserRoles.Where(ur => ur.RoleID != 1), "RoleID", "RoleName", user.RoleId);

            var selectedServices = _context.ServiceTechnicians.Where(u => u.TechniciansId == user.UserID);
            List<int> serviceIds = new List<int>();
            foreach (var st in selectedServices)
            {
                serviceIds.Add(st.ServicesId);
            }

            var viewModel = new NewUserViewModel
            {
                NewUser = user,
                Categories = _context.Categories,
                Services = new MultiSelectList(_context.Services, "ServiceID", "ServiceName", serviceIds),
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

            ApplicationUser? existingUser = await _context.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.UserID == userVM.NewUser.UserID);
            if (existingUser == null) { return NotFound(); }
            existingUser.PhoneNumber = userVM.NewUser.PhoneNumber;
            existingUser.FirstName = userVM.NewUser.FirstName;
            existingUser.LastName = userVM.NewUser.LastName;
            existingUser.City = userVM.NewUser.City;
            if (existingUser.RoleId != userVM.NewUser.RoleId)
            {
                string newRole = _context.UserRoles.Find(userVM.NewUser.RoleId).RoleName;
                IdentityUser idUser = await _userManager.FindByEmailAsync(existingUser.UserEmail);
                var userRole = await _userManager.GetRolesAsync(idUser);
                var removeResult = await _userManager.RemoveFromRoleAsync(idUser, existingUser.Role.RoleName);
                if (!removeResult.Succeeded)
                {
                    return NotFound();
                }
                var addResult = await _userManager.AddToRoleAsync(idUser, newRole);
                if (!addResult.Succeeded)
                {
                    return NotFound();
                }
                existingUser.RoleId = userVM.NewUser.RoleId;
            }
            
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    // loop through all technicians in the db and check which 
                    // have been modified for this service
                    var services = _context.Services.ToList();
                    for (int i = 0; i < services.Count(); i++)
                    {
                        Service service = services[i];
                        bool relationshipExists = _context.ServiceTechnicians
                            .Any(st => st.TechniciansId == existingUser.UserID
                            && st.ServicesId == service.ServiceID);

                        userVM.AssignedServicesIds ??= new List<int>();

                        if (!relationshipExists && userVM.AssignedServicesIds.Any(t => t == service.ServiceID))
                        {
                            // add if not already selected
                            _context.ServiceTechnicians.Add(new ServiceTechnician
                            {
                                TechniciansId = existingUser.UserID,
                                ServicesId = service.ServiceID
                            });
                        }
                        else if (relationshipExists && !userVM.AssignedServicesIds.Any(t => t == service.ServiceID))
                        {
                            // remove if deselected
                            _context.ServiceTechnicians.Remove(_context.ServiceTechnicians
                                .Single(st => st.TechniciansId == existingUser.UserID && st.ServicesId == service.ServiceID)
                                );
                        }
                    }
                    _context.Update(existingUser);
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!UserExists(existingUser.UserID))
                    {
                        return NotFound();
                    }
                    _context.LogException(ex, User, GetSourceRoute());
                } catch (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                }
                TempData["EditSuccess"] = "User Edited Successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.UserRoles.Where(ur => ur.RoleID != 1), "RoleID", "RoleName", existingUser.RoleId);
            var selectedServices = _context.ServiceTechnicians.Where(u => u.TechniciansId == existingUser.UserID);
            List<int> serviceIds = new List<int>();
            foreach (var st in selectedServices)
            {
                serviceIds.Add(st.ServicesId);
            }

            var viewModel = new NewUserViewModel
            {
                NewUser = existingUser,
                Categories = _context.Categories,
                Services = new MultiSelectList(_context.Services, "ServiceID", "ServiceName", serviceIds),
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
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }

                await _context.SaveAsync(User, GetSourceRoute(), null);
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
            }
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
            catch (Exception ex) 
            {
                _context.LogException(ex, User, GetSourceRoute());
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
