using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Context;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;
namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;
        public PalestrantePersistence(ProEventosContext context) { _context = context; }
       
        public async Task<Palestrante> PegaPalestrantePorIDAsync(int id, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .AsNoTracking()
                .Include(p => p.RedeSociais);
            if(incluirEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            return await query.FirstOrDefaultAsync(p => p.ID == id);
        }
        public async Task<Palestrante[]> PegaPalestrantesPorNomeAsync(string nome, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .AsNoTracking()
                .Include(p => p.RedeSociais);
            if(incluirEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query
                .OrderBy(p => p.ID)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> PegaTodosPalestrantesAsync(bool incluirEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                .AsNoTracking()
                .Include(p => p.RedeSociais);
            if(incluirEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }
            query = query.OrderBy(p => p.ID);
            return await query.ToArrayAsync();
        }
    }
}