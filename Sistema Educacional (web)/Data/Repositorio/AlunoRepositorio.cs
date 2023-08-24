using Sistema_Educacional__web_.Data.Repositorio.Interfaces;
using Sistema_Educacional__web_.Models;

namespace Sistema_Educacional__web_.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }

        public void EditarAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }

        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        
        //public List<Aluno> BuscarId(int Id)
        //{
        //    return _bancoContexto.Aluno.ToList();
        //}

        public Aluno BuscarId(int Id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Id == Id);
        }
    }
}
