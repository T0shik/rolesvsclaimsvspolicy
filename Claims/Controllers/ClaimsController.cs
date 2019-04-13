using Claims.AuthorizationAttributes;
using Microsoft.AspNetCore.Mvc;

namespace Claims.Controllers
{
    public class ClaimsController : Controller
    {
        public IActionResult Index() => View();

        [YearsWorked(2)]
        public IActionResult TwoYearRewards() => View();

        [YearsWorked(5)]
        public IActionResult FiveYearRewards() => View();

        [YearsWorked(10)]
        public IActionResult TenYearRewards() => View();
    }
}
