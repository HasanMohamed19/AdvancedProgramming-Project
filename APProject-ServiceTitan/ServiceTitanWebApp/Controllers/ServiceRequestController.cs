using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly ServiceTitanDBContext _context;

        public ServiceRequestController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        // GET: api/ServiceRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests()
        {
          if (_context.ServiceRequests == null)
          {
              return NotFound();
          }
            return await _context.ServiceRequests.ToListAsync();
        }

        // GET: api/ServiceRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
        {
          if (_context.ServiceRequests == null)
          {
              return NotFound();
          }
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);

            if (serviceRequest == null)
            {
                return NotFound();
            }

            return serviceRequest;
        }

        // PUT: api/ServiceRequest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRequest(int id, ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.RequestID)
            {
                return BadRequest();
            }

            _context.Entry(serviceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceRequest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> PostServiceRequest(ServiceRequest serviceRequest)
        {
          if (_context.ServiceRequests == null)
          {
              return Problem("Entity set 'ServiceTitanDBContext.ServiceRequests'  is null.");
          }
            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceRequest", new { id = serviceRequest.RequestID }, serviceRequest);
        }

        // DELETE: api/ServiceRequest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRequest(int id)
        {
            if (_context.ServiceRequests == null)
            {
                return NotFound();
            }
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            _context.ServiceRequests.Remove(serviceRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceRequestExists(int id)
        {
            return (_context.ServiceRequests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
