using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Rota.Domain.Interface;
using Rota.Entities.ViewModel;
using Rota.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rota.API.Controllers
{
    [Route("api/rotas")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _rotaService;

        public RotaController(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        [HttpGet("todas-rotas")]
        public async Task<ActionResult<List<RotaEntities>>> ObterTodasAsRotas()
        {
            try
            {
                var rotas = await _rotaService.ObterTodasAsRotas();
                if (rotas == null)
                    return NotFound();

                return rotas;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpGet("melhor-rota")]
        public async Task<ActionResult<RotaEntities>> ObterMelhorRota(string origem, string destino)
        {
            try
            {
                var rotas = await _rotaService.ObterMelhorRota(origem, destino);
                if (rotas == null)
                    return NotFound();

                return rotas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRota(RotaEntities rota)
        {
            var novaRota = await _rotaService.AdicionarRota(rota);
            return CreatedAtAction(nameof(ObterRotaPorId), new { id = novaRota.Id }, novaRota);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterRotaPorId(int id)
        {
            try
            {
                var rota = await _rotaService.ObterRotaPorId(id);
                if (rota == null)
                    return NotFound();

                return Ok(rota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarRota(int id, RotaEntities rota)
        {
            try
            {
                if (id != rota.Id)
                    return BadRequest();

                var rotaAtualizada = await _rotaService.AtualizarRota(id, rota);
                if (rotaAtualizada == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarRota(int id)
        {
            try
            {
                var rotaDeletada = await _rotaService.DeletarRota(id);
                if (!rotaDeletada)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

    }
}
