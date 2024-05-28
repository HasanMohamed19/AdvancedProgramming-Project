using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.Helpers;

namespace ServiceTitanWebApp.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly ServiceTitanDBContext _context;

        public NotificationController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            var serviceTitanDBContext = _context.Notifications.Include(n => n.NotificationStatus).Include(n => n.User);
            return View(await serviceTitanDBContext.ToListAsync());
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.NotificationStatus)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationID == id);
            if (notification == null)
            {
                return NotFound();
            }

            // update status to read
            notification.NotificationStatusId = 2;
            _context.Update(notification);
            _context.Save(User, GetSourceRoute(), null);

            return View(notification);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            ViewData["NotificationStatusId"] = new SelectList(_context.NotificationStatus, "NotificationStatusID", "NotificationStatusName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "FullName");
            return View();
        }

        // POST: Notification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotificationID,NotificationMessage,NotificationTitle,NotificationType,NotificationStatusId,UserId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveAsync(User, GetSourceRoute(), null);
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotificationStatusId"] = new SelectList(_context.NotificationStatus, "NotificationStatusID", "NotificationStatusName", notification.NotificationStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "FullName", notification.UserId);
            return View(notification);
        }

        // GET: Notification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["NotificationStatusId"] = new SelectList(_context.NotificationStatus, "NotificationStatusID", "NotificationStatusName", notification.NotificationStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "FullName", notification.UserId);
            return View(notification);
        }

        // POST: Notification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotificationID,NotificationMessage,NotificationTitle,NotificationType,NotificationStatusId,UserId")] Notification notification)
        {
            if (id != notification.NotificationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveAsync(User, GetSourceRoute(), null);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.NotificationID))
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
            ViewData["NotificationStatusId"] = new SelectList(_context.NotificationStatus, "NotificationStatusID", "NotificationStatusName", notification.NotificationStatusId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "FullName", notification.UserId);
            return View(notification);
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.NotificationStatus)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationID == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notifications == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Notifications'  is null.");
            }
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
            }

            await _context.SaveAsync(User, GetSourceRoute(), null);
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
          return (_context.Notifications?.Any(e => e.NotificationID == id)).GetValueOrDefault();
        }
    }
}
