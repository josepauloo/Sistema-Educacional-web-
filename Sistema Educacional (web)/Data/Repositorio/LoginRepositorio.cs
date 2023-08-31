using Sistema_Educacional__web_.Data.Repositorio.Interfaces;
using Sistema_Educacional__web_.Models;

namespace Sistema_Educacional__web_.Data.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public LoginRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public Login ValidarUsuario(Login login)
        {
            return _bancoContexto.Login.FirstOrDefault(a => a.Email == login.Email && a.Senha == login.Senha);
        }

    }
}
