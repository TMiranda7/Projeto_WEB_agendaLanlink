using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WEB_agendaLanlink.Models;
using WEB_agendaLanlink;
using WEB_agendaLanlink.Repositories.Contractors;
using System.Linq;

namespace WEB_agendaLanlink.Controllers
{
    public class HomeController : Controller
    {
        public readonly IPessoaRepository pessoaRepository;
        public readonly IEnderecoRepository enderecoRepository;
        public readonly ApplicationContext contexto;

        public HomeController(IPessoaRepository _pessoaRepository, IEnderecoRepository _enderecoRepository 
             , ApplicationContext _applicationContext)
        {
            this.pessoaRepository = _pessoaRepository;
            this.enderecoRepository = _enderecoRepository;
            this.contexto = _applicationContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View(pessoaRepository.ObterTodos());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if ( id == null )
            {
                return View();
            }
            var pessoa = contexto.pessoas.Where(x => x.Id == id).FirstOrDefault();
            pessoa.Endereco = contexto.enderecos.Where(e => e.Id == pessoa.enderecoId).FirstOrDefault();

            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Cadastro( Pessoa pessoa )
        {

            enderecoRepository.Add(pessoa.Endereco);
            pessoaRepository.Add(pessoa);

            return View();
        }
    }
}
