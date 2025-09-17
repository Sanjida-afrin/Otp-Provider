using Microsoft.AspNetCore.Mvc;

namespace OtpProvider.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
