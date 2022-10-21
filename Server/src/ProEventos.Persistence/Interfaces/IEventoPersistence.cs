using ProEventos.Domain;
namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersistence
    {
        Task<Evento[]> PegaEventosPorTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<Evento[]> PegaTodosEventosAsync(bool incluirPalestrantes = false);
        Task<Evento> PegaEventoPorIDAsync(int id, bool incluirPalestrantes = false);
    }
}