using Microsoft.AspNetCore.Mvc;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Controllers
{
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoController(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        [HttpGet("curso/{id}")]
        public async Task<List<Curso>> Exibir(string id)
        {
            return await _cursoRepositorio.ObterPorId(id);
        }

        [HttpGet("cursos")]
        public async Task<IEnumerable<Curso>> ObterTodos()
        {
            return await _cursoRepositorio.ObterTodos();
        }


        [HttpPost("curso")]
        public async Task<IActionResult> Adicionar(
            [FromBody] Curso model)
        {
            await _cursoRepositorio.Adicionar(model);
            return Ok(model);
        }


        [HttpPut("curso/{id}")]
        public async Task<IActionResult> Atualizar(
            Curso modelo)
        {
            await _cursoRepositorio.Atualizar(modelo);
            return Ok("The car has been sold");
        }

        [HttpDelete("professor/{id}")]
        public async Task<IActionResult> Deletar(
            string id)
        {
            await _cursoRepositorio.Deletar(id);
            return Ok("O ");
        }
    }
}
