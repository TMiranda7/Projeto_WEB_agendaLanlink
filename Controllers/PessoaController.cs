using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_agendaLanlink.Models;
using WEB_agendaLanlink.Repositories.Contractors;

namespace WEB_agendaLanlink.Controllers
{
    [Route("api/[controller]")]
    public class CadastroController : Controller
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IEnderecoRepository enderecoRepository;

        public CadastroController(IPessoaRepository _pessoaRepository , IEnderecoRepository _enderecoRepository )
        {
            pessoaRepository = _pessoaRepository;
            enderecoRepository = _enderecoRepository;
        }
        public IActionResult Contato()
        {
            return View(pessoaRepository.ObterTodos());
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(pessoaRepository.ObterTodos());
            }
            catch( Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                if(pessoa.Id > 0)
                {
                    pessoaRepository.Update(pessoa);
                }
                else
                {
                    pessoaRepository.Add(pessoa);
                }

                return Created("api/pessoa", pessoa);
            }
            catch( Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Pessoa pessoa)
        {
            try
            {
                pessoaRepository.Del(pessoa);
                return Json(pessoaRepository.ObterTodos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
