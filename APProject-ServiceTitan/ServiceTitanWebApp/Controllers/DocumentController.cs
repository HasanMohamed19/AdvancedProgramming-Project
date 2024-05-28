using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;
using ServiceTitanWebApp.Helpers;
using ServiceTitanWebApp.ViewModels;

namespace ServiceTitanWebApp.Controllers
{
    [Authorize]
    public class DocumentController : BaseController
    {
        private readonly ServiceTitanDBContext _context;

        public DocumentController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        // GET: Document
        public async Task<IActionResult> Index(int? requestId)
        {
            if (requestId == null) return NotFound();
            var documents = new UploadFilesViewModel
            {
                Documents = await _context.Documents
                    .Include(d => d.User)
                    .Where(s => s.ServiceRequestId == requestId).ToListAsync(),
                ServiceRequestId = requestId
            };
            return View(documents);
        }

        // GET: Document/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DocumentID == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Document/Create
        public IActionResult Create(int? requestId)
        {
            if (requestId == null) return NotFound();
            UploadFilesViewModel uploadFilesViewModel = new UploadFilesViewModel
            {
                Documents = new(),
                ServiceRequestId = requestId
            };
            return View(uploadFilesViewModel);
        }

        // POST: Document/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> files, string? description, int? requestId)
        {
            if (requestId == null) return NotFound();
            if (files.Count == 0) return NotFound();
            int thisUserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            try
            {
                foreach (var file in files)
                {
                    var basePath = Path.Combine(Directory.GetCurrentDirectory() + "Files");
                    bool basePathExists = Directory.Exists(basePath);
                    if (!basePathExists) Directory.CreateDirectory(basePath);
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(basePath, file.FileName);
                    //var extension = Path.GetExtension(file.FileName);
                    if (!System.IO.File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Document document = new Document
                        {
                            DocumentUploadDate = DateTime.UtcNow,
                            DocumentType = file.ContentType,
                            DocumentName = fileName,
                            DocumentDescription = description,
                            DocumentPath = filePath,
                            UserId = thisUserId,
                            ServiceRequestId = requestId
                        };
                        _context.Documents.Add(document);
                        await _context.SaveAsync(User, GetSourceRoute(), null);
                    }
                }
                TempData["CreateSuccess"] = "Files Uploaded Successfully";
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
                TempData["CreateFailed"] = "Could not upload files.";
            }
            return RedirectToAction(nameof(Index), new { requestId });
        }

        public async Task<IActionResult> Download(int? id)
        {
            try
            {
                var file = await _context.Documents.Where(x => x.DocumentID == id).FirstOrDefaultAsync();
                if (file == null) return null;
                var memory = new MemoryStream();
                using (var stream = new FileStream(file.DocumentPath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, file.DocumentType, file.DocumentName);
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
            }
            return null;
        }

        // GET: Document/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentID,DocumentDescription")] Document document)
        {
            if (id != document.DocumentID)
            {
                return NotFound();
            }
            Document? existingDocument = await _context.Documents.FirstOrDefaultAsync(x => x.DocumentID == id);
            if (existingDocument == null) { return NotFound(); }

            //int thisUserId = _context.Users.Single(u => u.UserEmail == User.Identity.Name).UserID;
            //if (!User.IsInRole("Admin")
            //    && !User.IsInRole("Manager")
            //    && existingDocument.UserId != thisUserId)
            //    return Forbid();

            existingDocument.DocumentDescription = document.DocumentDescription;

            try
            {
                _context.Update(existingDocument);
                await _context.SaveAsync(User, GetSourceRoute(), null);
                TempData["EditSuccess"] = "Document Saved Successfully";
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!DocumentExists(existingDocument.DocumentID))
                {
                    return NotFound();
                }
                _context.LogException(ex, User, GetSourceRoute());
                TempData["EditFailed"] = "Could not save document.";
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
                TempData["EditFailed"] = "Could not save document.";
            }
            return RedirectToAction(nameof(Index), new { requestId = existingDocument.ServiceRequestId });
        }

        // GET: Document/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DocumentID == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'ServiceTitanDBContext.Documents'  is null.");
            }
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            try
            {
                if (System.IO.File.Exists(document.DocumentPath))
                {
                    System.IO.File.Delete(document.DocumentPath);
                }
                _context.Documents.Remove(document);

                await _context.SaveAsync(User, GetSourceRoute(), null);
                TempData["DeleteSuccess"] = "Document Deleted Successfully";
            } catch (Exception ex)
            {
                _context.LogException(ex, User, GetSourceRoute());
                TempData["DeleteFailed"] = "Could not delete document.";
            }
            
            return RedirectToAction(nameof(Index), new { requestId = document.ServiceRequestId });
        }

        private bool DocumentExists(int id)
        {
          return (_context.Documents?.Any(e => e.DocumentID == id)).GetValueOrDefault();
        }
    }
}
