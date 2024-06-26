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
using ServiceTitanWebApp.Helpers;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    public class ServiceRequestController : BaseController
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
            // if this is technician, show only requests for him
            if (User.IsInRole(UserRole.GetRoleName(3)!))
            {
                requests = requests.Where(s => s.Technician != null && s.Technician.UserEmail == loggedInUserEmail);

                // search for client name
                if (!String.IsNullOrEmpty(searchName))
                {
                    requests = requests.Where(r => r.Client != null && r.Client.FullName!.Contains(searchName));
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
                // if this is User, show only requests for him
                requests = requests.Where(s => s.Client != null && s.Client.UserEmail == loggedInUserEmail);

                // search for client name
                if (!String.IsNullOrEmpty(searchName))
                {
                    requests = requests.Where(r => r.Client != null && r.Client.FullName!.Contains(searchName));
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
                // if this is admin or manager show all
                // no time to hide from manager
                // search for client name
                if (!String.IsNullOrEmpty(searchName))
                {
                    requests = requests.Where(r => r.Client != null && r.Client.FullName!.Contains(searchName));
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

            //if (serviceRequest.RequestDateNeeded < DateTime.Now.AddDays(2))
            //    TempData["CreateFailed"] = "Request must be at least 2 days after today.";

            
            serviceRequest.StatusId = 1; //pending
            serviceRequest.ClientId = _context.Users.Single(s => s.UserEmail == _userManager.GetUserName(User)).UserID;
            serviceRequest.RequestPrice = service.ServicePrice;
            serviceRequest.ServiceId = service.ServiceID;

            // add if valid
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(serviceRequest);
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                    SendCreateNotification(serviceRequest, service);
                    ApplicationUser u = _context.Users.Single(u => serviceRequest.ClientId == u.UserID);
                    EmailController.Instance().SendServiceRequestMade(u.UserEmail, u.UserEmail, u.FirstName, u.LastName, serviceRequest.RequestPrice.ToString());
                    TempData["CreateSuccess"] = "Request Created Successfully";
                } catch (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["CreateFailed"] = "Could not create request.";
                }
                return RedirectToAction(nameof(Index));
            }
            // invalid, refresh page
            ViewData["ServiceName"] = service.ServiceName;
            ViewData["ServicePrice"] = service.ServicePrice;


            var viewModel = new CreateRequestViewModel
            {
                Request = serviceRequest,
                ServiceId = service.ServiceID
            };
            return View(viewModel);
        }
        // unused admin functions
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
                try
                {
                    _context.Add(serviceRequest);
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                    SendCreateNotification(serviceRequest, service);
                    ApplicationUser u = _context.Users.Single(u => serviceRequest.ClientId == u.UserID);
                    EmailController.Instance().SendServiceRequestMade(u.UserEmail, u.UserEmail, u.FirstName, u.LastName, serviceRequest.RequestPrice.ToString());
                    TempData["CreateSuccess"] = "Request Created Successfully";
                }
                catch (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["CreateFailed"] = "Could not create request.";
                }
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

            var serviceRequest = await _context.ServiceRequests
                .Include(sr => sr.Service)
                .ThenInclude(s => s.ServiceTechnicians).
                SingleAsync(sr => sr.RequestID == id);

            if (serviceRequest == null)
            {
                return NotFound();
            }

            // make sure manager for different category cant edit this one
            ApplicationUser loggedInUser = _context.Users.Include(u => u.Role).Include(u => u.Category).Single(u => u.UserEmail == User.Identity.Name);
            if (User.IsInRole("Manager") && (loggedInUser.Category == null || (loggedInUser.Category != null && loggedInUser.Category.CategoryID != serviceRequest.Service.CategoryId)))
            {
                return Forbid();
            }
            // get all technicians inside this service resource pool
            var serviceTechs = serviceRequest.Service.ServiceTechnicians.ToList();
            List<ApplicationUser> technicians = new List<ApplicationUser>();
            foreach (var st in  serviceTechs)
            {
                technicians.Add(_context.Users.Single(u => u.UserID == st.TechniciansId));
            }


            //ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "FullName", serviceRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceName", serviceRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", serviceRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(technicians, "UserID", "FullName", serviceRequest.TechnicianId);
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
            ServiceRequest? existingRequest = _context.ServiceRequests
                .Include(s => s.Service)
                .SingleOrDefault(s => s.RequestID == id);
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

            // update if valid
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(existingRequest);
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                    SendEditNotification(existingRequest);
                    ApplicationUser u = _context.Users.Single(u => existingRequest.ClientId == u.UserID);
                    EmailController.Instance().SendServiceRequestUpdate(u.UserEmail, u.UserEmail, u.FirstName, u.LastName, existingRequest.RequestPrice.ToString());
                    TempData["EditSuccess"] = "Request Saved Successfully";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ServiceRequestExists(existingRequest.RequestID))
                    {
                        return NotFound();
                    }
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["EditFailed"] = "Could not save request.";
                } catch  (Exception ex)
                {
                    _context.LogException(ex, User, GetSourceRoute());
                    TempData["EditFailed"] = "Could not save request.";
                }
                return RedirectToAction(nameof(Index));
            }

            // invalid, refresh
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

            ApplicationUser loggedInUser = _context.Users.Include(u => u.Role).Include(u => u.Category).Single(u => u.UserEmail == User.Identity.Name);
            if (User.IsInRole("Manager") && (loggedInUser.Category == null || (loggedInUser.Category != null && loggedInUser.Category.CategoryID != serviceRequest.Service.CategoryId)))
            {
                return Forbid();
            }

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
            var serviceRequest = _context.ServiceRequests
                .Include(s => s.Service)
                .SingleOrDefault(s => s.RequestID == id);
            if (serviceRequest != null)
            {
                serviceRequest.StatusId = 4;

                // update in db
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(serviceRequest);
                        await _context.SaveAsync(User, GetSourceRoute(), null);
                        SendCancelNotification(serviceRequest);
                        SendCancelNotification(serviceRequest);
                        ApplicationUser u = _context.Users.Single(u => serviceRequest.ClientId == u.UserID);
                        EmailController.Instance().SendServiceRequestCancel(u.UserEmail, u.UserEmail, u.FirstName, u.LastName, serviceRequest.RequestPrice.ToString());
                        TempData["CancelSuccess"] = "Request Cancelled Successfully";
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!ServiceRequestExists(serviceRequest.RequestID))
                        {
                            return NotFound();
                        }
                        _context.LogException(ex, User, GetSourceRoute());
                        TempData["CancelFailed"] = "Could not cancel request.";
                    } catch (Exception ex)
                    {
                        _context.LogException(ex, User, GetSourceRoute());
                        TempData["CancelFailed"] = "Could not cancel request.";
                    }
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
            try
            {
                var serviceRequest = await _context.ServiceRequests.FindAsync(id);
                if (serviceRequest != null)
                {
                    _context.ServiceRequests.Remove(serviceRequest);
                }

                await _context.SaveAsync(User, GetSourceRoute(), null);
                if (serviceRequest.StatusId != 4 && serviceRequest.StatusId != 3)
                {
                    SendCancelNotification(serviceRequest);
                    ApplicationUser u = _context.Users.Single(u => serviceRequest.ClientId == u.UserID);
                    EmailController.Instance().SendServiceRequestCancel(u.UserEmail, u.UserEmail, u.FirstName, u.LastName, serviceRequest.RequestPrice.ToString());
                }
                TempData["DeleteSuccess"] = "Request Deleted Successfully";
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
                TempData["DeleteFailed"] = "Could not delete request.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceRequestExists(int id)
        {
          return (_context.ServiceRequests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
        private void SendCreateNotification(ServiceRequest serviceRequest, Service service)
        {
            Notification notif = new Notification
            {
                NotificationTitle = "Service Requested",
                NotificationMessage = $"The service {service.ServiceName} has been requested successfully.",
                NotificationType = "Request",
                NotificationStatusId = 1,
                UserId = serviceRequest.ClientId
            };
            if (serviceRequest.TechnicianId != null)
            {
                Notification notifTech = new Notification
                {
                    NotificationTitle = "Service Request Assigned",
                    NotificationMessage = $"A service request for {service.ServiceName} has been assigned to you.",
                    NotificationType = "Request",
                    NotificationStatusId = 1,
                    UserId = serviceRequest.TechnicianId
                };
                _context.Notifications.Add(notifTech);
            }
            _context.Notifications.Add(notif);
            _context.Save(User, GetSourceRoute(), null);
        }
        private void SendEditNotification(ServiceRequest serviceRequest)
        {
            Notification notif = new Notification
            {
                NotificationTitle = "Service Request Updated",
                NotificationMessage = $"The service request for {serviceRequest.Service?.ServiceName} has been updated.",
                NotificationType = "Request",
                NotificationStatusId = 1,
                UserId = serviceRequest.ClientId
            };
            if (serviceRequest.TechnicianId != null)
            {
                Notification notifTech = new Notification
                {
                    NotificationTitle = "Service Request Assigned",
                    NotificationMessage = $"A service request for {serviceRequest.Service?.ServiceName} has been assigned to you.",
                    NotificationType = "Request",
                    NotificationStatusId = 1,
                    UserId = serviceRequest.TechnicianId
                };
                _context.Notifications.Add(notifTech);
            }
            _context.Notifications.Add(notif);
            _context.Save(User, GetSourceRoute(), null);
        }
        private void SendCancelNotification(ServiceRequest serviceRequest)
        {
            Notification notif = new Notification
            {
                NotificationTitle = "Service Request Cancelled",
                NotificationMessage = $"The service request for {serviceRequest.Service?.ServiceName} has been cancelled.",
                NotificationType = "Request",
                NotificationStatusId = 1,
                UserId = serviceRequest.ClientId
            };
            if (serviceRequest.TechnicianId != null)
            {
                Notification notifTech = new Notification
                {
                    NotificationTitle = "Service Request Cancelled",
                    NotificationMessage = $"A service request for {serviceRequest.Service?.ServiceName} has been cancelled.",
                    NotificationType = "Request",
                    NotificationStatusId = 1,
                    UserId = serviceRequest.TechnicianId
                };
                _context.Notifications.Add(notifTech);
            }
            _context.Notifications.Add(notif);
            _context.Save(User, GetSourceRoute(), null);
        }
    }
}
