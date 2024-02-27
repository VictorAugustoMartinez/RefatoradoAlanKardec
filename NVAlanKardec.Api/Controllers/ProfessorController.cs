using Microsoft.AspNetCore.Mvc;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Controllers
{
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        [HttpGet("professor/{id}")]
        public async Task<List<Professor>> Exibir(string id)
        {
            return await _professorRepositorio.ObterPorId(id);
        }

        [HttpGet("professores")]
        public async Task<IEnumerable<Professor>> ObterTodos()
        {
            return await _professorRepositorio.ObterTodos();
        }


        [HttpPost("professor")]
        public async Task<IActionResult> Adicionar(
            [FromBody] Professor model)
        {
            await _professorRepositorio.Adicionar(model);
            return Ok(model);
        }


        [HttpPut("professor/{id}")]
        public async Task<IActionResult> Atualizar(
            Professor modelo)
        {
            await _professorRepositorio.Atualizar(modelo);
            return Ok("The car has been sold");
        }

        [HttpDelete("professor/{id}")]
        public async Task<IActionResult> Deletar(
            string id)
        {
            await _professorRepositorio.Deletar(id);
            return Ok("O ");
        }
    }
}
