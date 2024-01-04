using Microsoft.AspNetCore.Mvc;
using AgendaBlueApi.Services;
using AgendaBlueApi.Models;

namespace AgendaBlueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet]
        public async Task<IActionResult> TodosItens()
        {
            var agenda = await _agendaService.TodosItens();
            return Ok(agenda);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ItemPorId(int id)
        {
            var item = await _agendaService.ItemPorId(id);
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItem([FromBody] AgendaItemDto adicionarItem)
        {
            if (adicionarItem == null)
                return BadRequest();
            
            await _agendaService.AdicionarItem(adicionarItem);
            return CreatedAtAction(nameof(ItemPorId), new { id = adicionarItem.Id }, adicionarItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarItem(int id, [FromBody] AgendaItemDto editarItem)
        {
            if (editarItem == null || id != editarItem.Id)
                return BadRequest();
            
            var existeItem = await _agendaService.ItemPorId(id);
            if (existeItem == null)
                return NotFound();
            
            await _agendaService.EditarItem(id, editarItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirItem(int id)
        {
            var item = await _agendaService.ItemPorId(id);
            if (item == null)
                return NotFound();
            
            await _agendaService.ExcluirItem(id);
            return NoContent();
        }
    }
}
