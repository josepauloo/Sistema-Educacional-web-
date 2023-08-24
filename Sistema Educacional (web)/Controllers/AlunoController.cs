using Microsoft.AspNetCore.Mvc;
using Sistema_Educacional__web_.Data.Repositorio.Interfaces;
using Sistema_Educacional__web_.Models;
using System.Text.Json;

namespace Sistema_Educacional__web_.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int Id)
        {
            var aluno = _alunoRepositorio.BuscarId(Id);
            if (aluno == null)
            {
                TempData["MsgErro"] = "Aluno não encontrado";
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
        public IActionResult InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch(Exception e)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";
            }

            TempData["MsgSucesso"] = "Aluno inserido meu mano";

            return RedirectToAction("Index");
        }
        public IActionResult EditarAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.EditarAluno(aluno);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao alterar dados";
            }

            TempData["MsgSucesso"] = "Dados alterados meu mano";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if(result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions());

                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endereço! arruma ai bro";
                    return View("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

            ViewData["MsgSucesso"] = "Deu bom!";
            return View("Endereco", endereco);
        }
    }
}
