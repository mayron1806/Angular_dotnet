using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;
namespace ProEventos.Persistence
{
    public class GenericoPersistence : IGenericoPersistence
    {
        private readonly ProEventosContext _context;
        public GenericoPersistence(ProEventosContext context) { _context = context; }
        // GENERICO
        public void Adicionar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Atualizar<T>(T entity) where T : class
        {
             _context.Update(entity);
        }
        public void Deletar<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }
        public void DeletarVarios<T>(T entity) where T : class
        {
             _context.RemoveRange(entity);
        }
        public async Task<bool> SalvarMudancasAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}