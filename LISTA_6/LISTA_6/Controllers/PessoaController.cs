using Microsoft.AspNetCore.Mvc;
using LISTA_6.Services;
using LISTA_6.Models;
namespace LISTA_6.Controllers
{
    [ApiController]
    [Route("Api/")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar([FromBody] Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pessoaRepository.Adicionar(pessoa);

            return Ok($"{pessoa.Nome} Adicionada com sucesso.");
        }
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar(string cpf, Pessoa pessoa)
        {
            _pessoaRepository.Atualizar(cpf, pessoa);
            return Ok($"{pessoa.Nome} atualizada comsucesso!");
        }

        [HttpGet]
        [Route("Mostrar Lista")]
        public IActionResult MostrarLista()
        {
            var lista = _pessoaRepository.MostrarLista();
            return Ok(lista);
        }
        [HttpGet]
        [Route("Mostrar Lista IMC bom")]
        public IActionResult MostrarIMCBom()
        {
            var pessoasComIMCBom = _pessoaRepository.MostrarIMCBom();

            if (!pessoasComIMCBom.Any())
            {
                return NotFound("Nenhuma pessoa com IMC bom encontrada.");
            }

            return Ok(pessoasComIMCBom);
        }


        [HttpGet]
        [Route("Buscar Por CPF")]
        public IActionResult BuscarCpf(string cpf)
        {
            var pessoaPesquisada = _pessoaRepository.BuscarPorCPF(cpf);

            if (pessoaPesquisada is null)
            {
                return NotFound($"Pessoa com cpf {cpf} não encontrado.");
            }

            return Ok(pessoaPesquisada);
        }
        [HttpGet]
        [Route("Buscar Por Nome")]
        public IActionResult BuscarNome(string nome)
        {
            var pessoaPesquisada = _pessoaRepository.BuscarPorNome(nome);

            if (pessoaPesquisada is null)
            {
                return NotFound($"Pessoa {nome} não encontrado.");
            }

            return Ok(pessoaPesquisada);
        }
        
        [HttpDelete]
        [Route("Remover")]
        public IActionResult Deletar(string cpf)
        {
            if(cpf is null)
            {
                return NotFound("Pessoa não encontrada");
            }
            _pessoaRepository.Deletar(cpf);
            return Ok("Pessoa Removida com sucesso");
        }

    }
}
