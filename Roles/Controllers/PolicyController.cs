using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Roles.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index() => View();

        [Authorize(Policy = "UserAccess")]
        public IActionResult UserPage() => View();

        [Authorize(Policy = "ManagerAccess")]
        public IActionResult ManagerPage() => View();

        [Authorize(Policy = "AdminAccess")]
        public IActionResult AdminPage() => View();
    }
}
