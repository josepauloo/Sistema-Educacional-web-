using Sistema_Educacional__web_.Models;

namespace Sistema_Educacional__web_.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);
        void ExcluirAluno(int id);
        void EditarAluno(Aluno aluno);
        Aluno BuscarId(int id);
    }
}
