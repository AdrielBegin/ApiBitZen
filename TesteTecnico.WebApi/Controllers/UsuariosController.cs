using Microsoft.AspNetCore.Mvc;

namespace TesteTecnico.WebApi.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
