using Microsoft.AspNetCore.Mvc;
using Sistema_Educacional__web_.Models;
using System.Text.Json;

namespace Sistema_Educacional__web_.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        public AlunoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
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

                }
            }
            catch (Exception)
            {

                throw;
            }


            return View("Index");
        }
    }
}
