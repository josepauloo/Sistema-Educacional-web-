using Microsoft.AspNetCore.Mvc;
using Sistema_Educacional__web_.Data.Repositorio.Interfaces;
using Sistema_Educacional__web_.Models;

namespace Sistema_Educacional__web_.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _loginRepositorio;

        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscarLogin(Login login)
        {
            try
            {
                var acesso = _loginRepositorio.ValidarUsuario(login);

                if (acesso != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MsgErro"] = "Email ou senha incorreto, tente novamente!";
                }
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao buscar os dados do usuário";
            }
            return RedirectToAction("Index");
        }
    }
}
