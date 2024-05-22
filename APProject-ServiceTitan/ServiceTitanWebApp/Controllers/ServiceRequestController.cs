using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ServiceTitanDBContext _context;

        public ServiceRequestController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        // GET: ServiceRequest
        public async Task<IActionResult> Index()
        {
            var serviceTitanDBContext = _context.ServiceRequests.Include(s => s.Client).Include(s => s.Service).Include(s => s.Status).Include(s => s.Technician);
            return View(await serviceTitanDBContext.ToListAsync());
        }

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
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "Password");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceDescription");
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status");
            ViewData["TechnicianId"] = new SelectList(_context.Users, "UserID", "Password");
            return View();
        }

        // POST: ServiceRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,RequestDescription,RequestPrice,RequestDateNeeded,ClientId,TechnicianId,ServiceId,StatusId")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "Password", serviceRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceDescription", serviceRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", serviceRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(_context.Users, "UserID", "Password", serviceRequest.TechnicianId);
            return View(serviceRequest);
        }

        // GET: ServiceRequest/Edit/5
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
            ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "Password", serviceRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceDescription", serviceRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", serviceRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(_context.Users, "UserID", "Password", serviceRequest.TechnicianId);
            return View(serviceRequest);
        }

        // POST: ServiceRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,RequestDescription,RequestPrice,RequestDateNeeded,ClientId,TechnicianId,ServiceId,StatusId")] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.RequestID)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Users, "UserID", "Password", serviceRequest.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceID", "ServiceDescription", serviceRequest.ServiceId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "StatusID", "Status", serviceRequest.StatusId);
            ViewData["TechnicianId"] = new SelectList(_context.Users, "UserID", "Password", serviceRequest.TechnicianId);
            return View(serviceRequest);
        }

        // GET: ServiceRequest/Delete/5
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
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceRequestExists(int id)
        {
          return (_context.ServiceRequests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
