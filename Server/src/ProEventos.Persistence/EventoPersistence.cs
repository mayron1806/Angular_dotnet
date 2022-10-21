using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context) { _context = context; }
       

        // EVENTOS

        public async Task<Evento[]> PegaTodosEventosAsync(bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .AsNoTracking()
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);
            if(incluirPalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.ID);
            return await query.ToArrayAsync();
        }
        public async Task<Evento> PegaEventoPorIDAsync(int id, bool incluirPalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .AsNoTracking()
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);
            if(incluirPalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            return await query.FirstOrDefaultAsync(e => e.ID == id);
        }
        public async Task<Evento[]> PegaEventosPorTemaAsync(string tema, bool incluirPalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .AsNoTracking()
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);
            if(incluirPalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }
            query = query
                .OrderBy(e => e.ID)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            
            return await query.ToArrayAsync();
        }
    }
}