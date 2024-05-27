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
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ServiceTitanDBContext _context;

        public CommentController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        // GET: Comment
        public IActionResult Index(int? requestId)
        {
            if (requestId == null) return NotFound();
            var comments = _context.Comments
                .Include(c => c.ServiceRequest)
                .Include(c => c.User)
                .Where(u => u.ServiceRequestId == requestId);
            RequestCommentsViewModel commentsViewModel = new RequestCommentsViewModel
            {
                Comments = comments,
                RequestId = requestId
            };
            return View(commentsViewModel);
        }

        // GET: Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.ServiceRequest)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comment/Create
        public IActionResult Create(int? requestId)
        {
            if (requestId == null) return NotFound();
            Comment comment = new Comment();
            comment.ServiceRequestId = requestId;
            return View(comment);
        }

        // POST: Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentID,CommentText,ServiceRequestId")] Comment comment)
        {
            comment.UserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            comment.CommentDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { requestId = comment.ServiceRequestId });
            }

            return View(comment);
        }

        // GET: Comment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            // dont allow technicians or clients to edit other users comments
            int thisUserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            if (!User.IsInRole("Admin")
                && !User.IsInRole("Manager")
                && comment.UserId != thisUserId)
                return Forbid();

            //ViewData["ServiceRequestId"] = new SelectList(_context.ServiceRequests, "RequestID", "RequestID", comment.ServiceRequestId);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserID", "Password", comment.UserId);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentID,CommentText,ServiceRequestId")] Comment comment)
        {
            if (id != comment.CommentID)
            {
                return NotFound();
            }
            Comment existingComment = _context.Comments.Find(id);
            if (existingComment == null) { return NotFound(); }

            // dont allow technicians or clients to edit other users comments
            int thisUserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            if (!User.IsInRole("Admin")
                && !User.IsInRole("Manager")
                && existingComment.UserId != thisUserId)
                return Forbid();

            existingComment.CommentText = comment.CommentText;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(existingComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(existingComment.CommentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { requestId = existingComment.ServiceRequestId });
            }
            //ViewData["ServiceRequestId"] = new SelectList(_context.ServiceRequests, "RequestID", "RequestID", comment.ServiceRequestId);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserID", "Password", comment.UserId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.ServiceRequest)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentID == id);
            if (comment == null)
            {
                return NotFound();
            }
            // dont allow technicians or clients to delete other users comments
            int thisUserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            if (!User.IsInRole("Admin")
                && !User.IsInRole("Manager")
                && comment.UserId != thisUserId)
                return Forbid();

            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Comments'  is null.");
            }
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                int thisUserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
                if (!User.IsInRole("Admin") 
                    && !User.IsInRole("Manager") 
                    && comment.UserId != thisUserId) 
                    return Forbid();
                _context.Comments.Remove(comment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { requestId = comment.ServiceRequestId });
        }

        private bool CommentExists(int id)
        {
          return (_context.Comments?.Any(e => e.CommentID == id)).GetValueOrDefault();
        }
    }
}
