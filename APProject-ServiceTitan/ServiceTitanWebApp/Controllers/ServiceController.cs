using Microsoft.AspNetCore.Mvc;
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceTitanDBContext _context;

        public ServiceController(ServiceTitanDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getService(int id)
        {
            Service serviceList = _context.Services.Find(id);
            return Json(serviceList);
        }

        public IActionResult getAllServices()
        {
            IEnumerable<Service> serviceList = _context.Services;
            return Json(serviceList);
        }
    }
}
