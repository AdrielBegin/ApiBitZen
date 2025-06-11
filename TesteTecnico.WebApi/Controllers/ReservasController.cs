using Microsoft.AspNetCore.Mvc;

namespace TesteTecnico.WebApi.Controllers
{
    public class ReservasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
