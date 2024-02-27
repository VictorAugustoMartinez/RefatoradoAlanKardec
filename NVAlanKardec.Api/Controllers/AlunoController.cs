using Microsoft.AspNetCore.Mvc;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Controllers
{
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet("aluno/{id}")]
        public async Task<List<Aluno>> Exibir(string id)
        {
            return await _alunoRepositorio.ObterPorId(id);
        }

        [HttpGet("alunos")]
        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _alunoRepositorio.ObterTodos();
        }


        [HttpPost("aluno")]
        public async Task<IActionResult> Adicionar(
            [FromBody] Aluno model)
        {
            await _alunoRepositorio.Adicionar(model);
            return Ok(model);
        }


        [HttpPut("aluno/{id}")]
        public async Task<IActionResult> Atualizar(
            Aluno modelo)
        {
            await _alunoRepositorio.Atualizar(modelo);
            return Ok("The car has been sold");
        }

        [HttpDelete("aluno/{id}")]
        public async Task<IActionResult> Deletar(
            string id)
        {
            await _alunoRepositorio.Deletar(id);
            return Ok("O ");
        }
    }
}

