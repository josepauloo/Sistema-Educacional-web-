using Microsoft.AspNetCore.Mvc;

namespace Sistema_Educacional__web_.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
