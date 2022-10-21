using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Application.Interfaces;

namespace ProEventos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;
    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }
    // GET
    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> PegaPorID(int id)
    {
        try
        {
            var evento = await _eventoService.PegaEventoPorIDAsync(id: id, incluirPalestrantes: true);
            return Ok(evento);
        }
        catch(NullReferenceException e){
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
   
    [HttpGet("tema/{tema}")]
    public async Task<IActionResult> PegaPorTema(string tema)
    {
        try
        {
            var eventos = await _eventoService.PegaEventosPorTemaAsync(tema: tema, incluirPalestrantes: true);
            return Ok(eventos);
        }
        catch(NullReferenceException e){
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> PegaTodos()
    {
        try
        {
            var eventos = await _eventoService.PegaTodosEventosAsync(incluirPalestrantes: true);
            return Ok(eventos);
        }
        catch(NullReferenceException e){
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }


    // POST
    [HttpPost]
    public async Task<IActionResult> AdicionarEvento(Evento model)
    {
        try
        {
            var evento = await _eventoService.AdicionarEvento(model);
            if(evento == null) return BadRequest("Erro ao tentar adicionar evento.");
            return CreatedAtAction(nameof(PegaPorID), new {id = evento.ID}, evento);
        }
        catch(NullReferenceException e){
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarEvento(int id,  Evento model)
    {
        try
        {
            var evento = await _eventoService.AtualizarEvento(id, model);
            if(evento == null) return BadRequest("Erro ao tentar adicionar evento.");
            return CreatedAtAction(nameof(PegaPorID), new {id = evento.ID}, evento);
        }
        catch(NullReferenceException e){
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarEvento(int id)
    {
        try
        {
            return await _eventoService.DeletarEvento(id) ? 
                Ok("Deletado com sucesso") : 
                BadRequest("Erro ao tentar deletar evento.");
        }
        catch(NullReferenceException e){
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}
