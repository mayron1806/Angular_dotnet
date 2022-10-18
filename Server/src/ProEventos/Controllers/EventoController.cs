using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Models;
namespace ProEventos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public List<Evento> eventos = new List<Evento> {
        new Evento()
        {
            ID = 1,
            Tema = "Jogos",
            Local = "Sete Lagoas",
            Lote = "1",
            QuantodadePessoas = 300,
            DataEvento = DateTime.Now.AddDays(20).ToString(),
            ImagemURL = "evento.jpg"
        },
        new Evento()
        {
            ID = 2,
            Tema = "Jogos",
            Local = "Sete Lagoas",
            Lote = "1",
            QuantodadePessoas = 300,
            DataEvento = DateTime.Now.AddDays(20).ToString(),
            ImagemURL = "evento2.jpg"
        }
    };
    [HttpGet("{id}")]
    public Evento Pega(int id)
    {
        return eventos.Where(e => e.ID == id).First();
    }
     [HttpGet]
    public IEnumerable<Evento> PegaTodos()
    {
        return eventos;
    }
    [HttpPost]
    public string Inserir()
    {
        return "post";
    }
}
