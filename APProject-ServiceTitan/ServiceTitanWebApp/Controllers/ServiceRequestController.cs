using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ServiceTitanDBContext _context;

        public ServiceRequestController(ServiceTitanDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ServiceRequest
        [Authorize]
        public IActionResult Index(string searchName, string searchStatus)
        {
            string loggedInUserEmail = _userManager.GetUserName(User);
            IEnumerable<ServiceRequest> requests = _context.ServiceRequests
                .Include(s => s.Client)
                .Include(s => s.Service)
                .Include(s => s.Status)
                .Include(s => s.Technician);
            if (User.IsInRole(UserRole.GetRoleName(3)!))
            {
                requests = requests.Where(s => s.Technician.UserEmail == loggedInUserEmail);

                // search for client name
                if (!String.IsNullOrEmpty(searchName))
                {
                    requests = requests.Where(r => r.Client.FullName!.Contains(searchName));
                }

                // search for status
                if (!String.IsNullOrEmpty(searchStatus))
                {
                    requests = requests.Where(r => r.StatusId == Convert.ToInt32(searchStatus));
                }

                var requestIndexVM = new ServiceRequestIndexViewModel
                {
                    ServiceRequests = requests,
                    RequestStatuses = _context.RequestStatus,
                };

                return View(requestIndexVM);
            }
            else if (User.IsInRole(UserRole.GetRoleName(4)!))
            {
                requests = requests.Where(s => s.Client.UserEmail == loggedInUserEmail);

                // search for client name
                if (!String.IsNullOrEmpty(searchName))
                {
                    requests = requests.Where(r => r.Client.FullName!.Contains(searchName));
                }

                // search for status
                if (!String.IsNullOrEmpty(searchStatus))
                {
                    requests = requests.Where(r => r.StatusId == Convert.ToInt32(searchStatus));
                }

                var requestIndexVM = new ServiceRequestIndexViewModel
                {
                    ServiceRequests = requests,
                    RequestStatuses = _context.RequestStatus,
                };

                return View(requestIndexVM);
            } else if (User.IsInRole(UserRole.GetRoleName(1)!) || User.IsInRole(UserRole.GetRoleName(2)!))
            {

                // search for client name
                if (!String.IsNullOrEmpty(searchName))
                {
                    requests = requests.Where(r => r.Client.FullName!.Contains(searchName));
                }

                // search for status
                if (!String.IsNullOrEmpty(searchStatus))
                {
                    requests = requests.Where(r => r.StatusId == Convert.ToInt32(searchStatus));
                }

                var requestIndexVM = new ServiceRequestIndexViewModel
                {
                    ServiceRequests = requests,
                    RequestStatuses = _context.RequestStatus,
                };

                return View(requestIndexVM);
            }
            // if none of the roles match, dont return anything
            return View();
        }

        // GET: ServiceRequest
        //public IActionResult Index(string UserEmail)
        //{
        //    IEnumerable<ServiceRequest> requests = _context.ServiceRequests
        //        .Include(s => s.Client)
        //        .Include(s => s.Service)
        //        .Include(s => s.Status)
        //        .Include(s => s.Technician);
        //    if (User.IsInRole(UserRole.GetRoleName(3)!))
        //    {
        //        requests = requests.Where(s => s.Technician.UserEmail == UserEmail);
        //    } else if (User.IsInRole(UserRole.GetRoleName(4)!))
        //    {
        //        requests = requests.Where(s => s.Client.UserEmail == UserEmail);
        //    } 
        //    //else if (User.IsInRole(UserRole.GetRoleName(1)!) || User.IsInRole(UserRole.GetRoleName(2)!))
        //    //{
        //    //    requests = requests;
        //    //}


        //    return View(requests.ToList());
        //}

        // GET: ServiceRequest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceRequests == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests
                .Include(s => s.Client)
                .Include(s => s.Service)
                .Include(s => s.Status)
                .Include(s => s.Technician)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // GET: ServiceRequest/Create
        //public IActionResult Create()
        //{
        //    ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceName");
        //    //ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status");
        //    //ViewData["TechnicianId"] = new SelectList(_context.Users.Where(s => s.RoleId == 3), "UserID", "FullName");
        //    return View();
        //}

        [Authorize]
        public IActionResult Create(int? id)
        {
            if (id == null)
                return NotFound();

            Service? service = _context.Services.Find(id);
            if (service == null)
                return NotFound();

            ViewData["ServiceName"] = service.ServiceName;
            ViewData["ServicePrice"] = service.ServicePrice;

            var viewModel = new CreateRequestViewModel
            {
                Request = new ServiceRequest(),
                ServiceId = id
            };
            return View(viewModel);
        }

        // POST: ServiceRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Request,ServiceId")] CreateRequestViewModel newRequestVM)
        {
            
            ServiceRequest? serviceRequest = newRequestVM.Request;
            if (serviceRequest == null) { return NotFound(); }
            Service? service = _context.Services.Find(newRequestVM.ServiceId);
            if (service == null) { return NotFound(); }

            serviceRequest.StatusId = 1; //pending
            serviceRequest.ClientId = _context.Users.Single(s => s.UserEmail == _userManager.GetUserName(User)).UserID;
            serviceRequest.RequestPrice = service.ServicePrice;
            serviceRequest.ServiceId = service.ServiceID;

            if (ModelState.IsValid)
            {
                _context.Add(serviceRequest);
                await _context.SaveChangesAsync();
                TempData["CreateSuccess"] = "Request Created Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewData["ServiceName"] = service.ServiceName;
            ViewData["ServicePrice"] = service.ServicePrice;


            var viewModel = new CreateRequestViewModel
            {
                Request = serviceRequest,
                ServiceId = service.ServiceID
            };
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminCreate(int? id)
        {
            if (id == null)
                return NotFound();

            Service? service = _context.Services.Find(id);
            if (service == null)
                return NotFound();

            //ViewData["ServiceName"] = service.ServiceName;
            //ViewData["ServicePrice"] = service.ServicePrice;
            ViewData["ClientId"] = new SelectList(_context.Users.Where(u => u.RoleId == 4), "UserID", "FullName", 0);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceName", id);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", 0);
            ViewData["TechnicianId"] = new SelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", 0);

            var viewModel = new CreateRequestViewModel
            {
                Request = new ServiceRequest(),
                ServiceId = id
            };
            return View(viewModel);
        }

        // POST: ServiceRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminCreate(CreateRequestViewModel requestVM)
        {
            ServiceRequest? serviceRequest = requestVM.Request;
            if (serviceRequest == null) { return NotFound(); }
            Service? service = _context.Services.Find(serviceRequest.ServiceId);
            if (service == null) { return NotFound(); }

            if (ModelState.IsValid)
            {
                _context.Add(serviceRequest);
                await _context.SaveChangesAsync();
                TempData["CreateSuccess"] = "Request Created Successfully";
                return RedirectToAction(nameof(Index));
            }

            //ViewData["ServiceName"] = service.ServiceName;
            //ViewData["ServicePrice"] = service.ServicePrice;
            ViewData["ClientId"] = new SelectList(_context.Users.Where(u => u.RoleId == 4), "UserID", "FullName", serviceRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceName", serviceRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", serviceRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", serviceRequest.TechnicianId);


            var viewModel = new CreateRequestViewModel
            {
                Request = serviceRequest,
                ServiceId = serviceRequest.ServiceId
            };
            return View(viewModel);
        }

        // GET: ServiceRequest/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceRequests == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            //ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "FullName", serviceRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceName", serviceRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", serviceRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", serviceRequest.TechnicianId);
            return View(serviceRequest);
        }

        // POST: ServiceRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,RequestDescription,RequestPrice,RequestDateNeeded,ClientId,TechnicianId,ServiceId,StatusId")] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.RequestID)
            {
                return NotFound();
            }
            ServiceRequest? existingRequest = _context.ServiceRequests.Find(id);
            if (existingRequest == null) { return NotFound(); }

            existingRequest.RequestDescription = serviceRequest.RequestDescription;

            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("Technician"))
            {
                existingRequest.StatusId = serviceRequest.StatusId;
                existingRequest.RequestDateNeeded = serviceRequest.RequestDateNeeded;
                if (!User.IsInRole("Technician"))
                {
                    existingRequest.ServiceId = serviceRequest.ServiceId;
                    existingRequest.TechnicianId = serviceRequest.TechnicianId;
                    existingRequest.RequestPrice = serviceRequest.RequestPrice;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(existingRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceRequestExists(existingRequest.RequestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["EditSuccess"] = "Request Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "FullName", existingRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceName", existingRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", existingRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(_context.Users.Where(u => u.RoleId == 3), "UserID", "FullName", existingRequest.TechnicianId);
            return View(serviceRequest);
        }

        [Authorize]
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null || _context.ServiceRequests == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests
                .Include(s => s.Service)
                .Include(s => s.Status)
                .Include(s => s.Technician)
                .FirstOrDefaultAsync(m => m.RequestID == id);

            if (serviceRequest == null) { return NotFound(); }

            
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            if (_context.ServiceRequests == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.ServiceRequests'  is null.");
            }
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest != null)
            {
                serviceRequest.StatusId = 4;

                // update in db
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(serviceRequest);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ServiceRequestExists(serviceRequest.RequestID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    TempData["CancelSuccess"] = "Request Cancelled Successfully";
                }
            }

            return RedirectToAction(nameof(Index));
        }


        // Deleting requests only possible for admin

        // GET: ServiceRequest/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceRequests == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests
                .Include(s => s.Client)
                .Include(s => s.Service)
                .Include(s => s.Status)
                .Include(s => s.Technician)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceRequests == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.ServiceRequests'  is null.");
            }
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest != null)
            {
                _context.ServiceRequests.Remove(serviceRequest);
            }
            
            await _context.SaveChangesAsync();
            TempData["DeleteSuccess"] = "Request Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceRequestExists(int id)
        {
          return (_context.ServiceRequests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
