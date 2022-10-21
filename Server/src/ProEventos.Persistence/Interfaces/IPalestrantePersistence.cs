using ProEventos.Domain;
namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantePersistence
    {
        Task<Palestrante[]> PegaPalestrantesPorNomeAsync(string nome, bool incluirEventos = false);
        Task<Palestrante[]> PegaTodosPalestrantesAsync(bool incluirEventos = false);
        Task<Palestrante> PegaPalestrantePorIDAsync(int id, bool incluirEventos = false);
    }
}