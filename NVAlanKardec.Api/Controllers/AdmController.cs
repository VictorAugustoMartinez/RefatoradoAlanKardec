using Microsoft.AspNetCore.Mvc;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;
using System.Runtime.Intrinsics.Arm;

namespace NVAlanKardec.Api.Controllers
{
    [ApiController]
    public class AdmController : ControllerBase
    {
        private readonly IAdmRepositorio _admRepositorio;

        public AdmController(IAdmRepositorio admRepositorio)
        {
            _admRepositorio = admRepositorio;
        }

        [HttpGet("adm/{id}")]
        public async Task<List<Adm>> Exibir(string id)
        {
            return await _admRepositorio.ObterPorId(id);
        }

        [HttpGet("adms")]
        public async Task<IEnumerable<Adm>> ObterTodos()
        {
            return await _admRepositorio.ObterTodos();
        }


        [HttpPost("adm")]
        public async Task<IActionResult> Adicionar(
            [FromBody] Adm model)
        {
            await _admRepositorio.Adicionar(model);
            return Ok(model);
        }


        [HttpPut("adm/{id}")]
        public async Task<IActionResult> Atualizar(
            Adm modelo)
        {
            await _admRepositorio.Atualizar(modelo);
            return Ok("The car has been sold");
        }

        [HttpDelete("adm/{id}")]
        public async Task<IActionResult> Deletar(
            string id)
        {
            await _admRepositorio.Deletar(id);
            return Ok("O ");
        }
    }
}

