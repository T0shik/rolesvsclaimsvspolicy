using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claims.Controllers
{

    public class PolicyController : Controller
    {
        public IActionResult Index() => View();

        [Authorize(Policy = "WorkedTwoYears")]
        public IActionResult TwoYearRewards() => View();

        [Authorize(Policy = "WorkedFiveYears")]
        public IActionResult FiveYearRewards() => View();

        [Authorize(Policy = "WorkedTenYears")]
        public IActionResult TenYearRewards() => View();
    }
}
