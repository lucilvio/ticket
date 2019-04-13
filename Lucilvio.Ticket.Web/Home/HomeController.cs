using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.Ticket.Web.Home
{
    [Route(""), Route("Home")]
    public class HomeController : Controller
    {
        [HttpGet, Route(""), Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
