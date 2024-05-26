using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewComponents
{
    [ViewComponent(Name = "NotificationBar")]
    public class NotificationBarViewComponent : ViewComponent
    {
        private readonly ServiceTitanDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public NotificationBarViewComponent(ServiceTitanDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userEmail = User.Identity.Name;
            int notificationCount = _context.Notifications.Where(u => u.User.UserEmail == userEmail).Count();

            return View("Index", notificationCount);
        }
    }
}
