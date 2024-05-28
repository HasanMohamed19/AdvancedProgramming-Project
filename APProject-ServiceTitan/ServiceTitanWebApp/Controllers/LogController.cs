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

    [Authorize(Roles ="Admin")]
    public class LogController : Controller
    {
        private readonly ServiceTitanDBContext _context;

        public LogController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        // GET: Log
        //public async Task<IActionResult> Index()
        //{
        //    var serviceTitanDBContext = _context.Logs.Include(l => l.User);
        //    return View(await serviceTitanDBContext.ToListAsync());
        //}

        public IActionResult Index(string searchLogType, string searchUser)
        {
            //IQueryable<Log> logs = _context.Logs.Include(l => l.LogType);
            IEnumerable<Log> logs;

            // if no filter is used
            logs = _context.Logs
                .Include(l => l.User)
                .OrderByDescending(l => l.Time);

            if (!String.IsNullOrEmpty(searchUser))
                searchUser = searchUser.ToLower();

            // search for log type
            if (!String.IsNullOrEmpty(searchLogType))
            {
                logs = logs.Where(l => l.Type.Contains(searchLogType));
            }

            if (!String.IsNullOrEmpty(searchUser))
            {
                logs = logs.Where(l => l.User.UserEmail.ToLower().Contains(searchUser)
                        || l.User.FullName.ToLower().Contains(searchUser)
                        || l.Source.ToLower().Contains(searchUser)
                        || l.Message.ToLower().Contains(searchUser)
                        || l.OriginalValue.ToLower().Contains(searchUser)
                        || l.CurrentValue.ToLower().Contains(searchUser)) ;
            }

            var logIndexVM = new LogIndexViewModel
            {
                Logs = logs,
                LogTypes = _context.Logs.Select(l => l.Type).Distinct().ToList()
            };

            return View(logIndexVM);
        }


        // GET: Log/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Log/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "Password");
            return View();
        }

        // POST: Log/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogID,Source,Time,Message,OriginalValue,CurrentValue,Type,UserId")] Log log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "Password", log.UserId);
            return View(log);
        }

        // GET: Log/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "Password", log.UserId);
            return View(log);
        }

        // POST: Log/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogID,Source,Time,Message,OriginalValue,CurrentValue,Type,UserId")] Log log)
        {
            if (id != log.LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogExists(log.LogID))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserID", "Password", log.UserId);
            return View(log);
        }

        // GET: Log/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logs == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Logs'  is null.");
            }
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(int id)
        {
          return (_context.Logs?.Any(e => e.LogID == id)).GetValueOrDefault();
        }
    }
}
