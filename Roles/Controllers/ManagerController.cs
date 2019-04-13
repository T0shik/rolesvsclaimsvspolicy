using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Roles.Controllers
{
    [Authorize(Roles = "Manger")]
    public class ManagerController : Controller
    {
        public IActionResult Index() => View();
    }
}
