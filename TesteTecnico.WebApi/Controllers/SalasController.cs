using Microsoft.AspNetCore.Mvc;

namespace TesteTecnico.WebApi.Controllers
{
    public class SalasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
