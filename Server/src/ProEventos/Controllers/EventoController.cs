using Microsoft.AspNetCore.Mvc;
using ProEventos.Data;
using ProEventos.Models;
namespace ProEventos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _context;
    public EventoController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public Evento Pega(int id)
    {
        return _context.Eventos.FirstOrDefault(e => e.ID == id);
    }
    [HttpGet]
    public IEnumerable<Evento> PegaTodos()
    {
        return _context.Eventos.ToList();
    }
    [HttpPost]
    public string Inserir()
    {
        return "post";
    }
}
