using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AdicionarEvento(Evento novoEvento);
        Task<Evento> AtualizarEvento(int eventoID, Evento evento);
        Task<bool> DeletarEvento(int eventoID);
        Task<Evento[]> PegaEventosPorTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<Evento[]> PegaTodosEventosAsync(bool incluirPalestrantes = false);
        Task<Evento> PegaEventoPorIDAsync(int id, bool incluirPalestrantes = false);
    }
}