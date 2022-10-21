using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGenericoPersistence _generico;
        private readonly IEventoPersistence _evento;

        public EventoService(IGenericoPersistence generico, IEventoPersistence evento)
        {
            _evento = evento;
            _generico = generico;
        }
        public async Task<Evento> AdicionarEvento(Evento novoEvento)
        {
            try
            {
                _generico.Adicionar<Evento>(novoEvento);
                bool foiSalvo = await _generico.SalvarMudancasAsync();
                if(foiSalvo){
                    return novoEvento;
                }else{
                    throw new Exception("Erro ao salvar o evento.");
                }
            }   
            catch (System.Exception e )
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Evento> AtualizarEvento(int eventoID, Evento evento)
        {
            try
            {
                var eventoBanco = await _evento.PegaEventoPorIDAsync(eventoID);
                if(eventoBanco == null) throw new Exception("O evento não existe.");

                evento.ID = eventoBanco.ID;
                _generico.Atualizar<Evento>(evento);
                bool foiSalvo = await _generico.SalvarMudancasAsync();
                if(foiSalvo) return evento;

                throw new Exception("Erro ao atualizar evento.");
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> DeletarEvento(int eventoID)
        {
            try
            {
                var eventoBanco = await _evento.PegaEventoPorIDAsync(eventoID);
                if(eventoBanco is null) throw new Exception("O evento não existe.");

                _generico.Deletar<Evento>(eventoBanco);
                bool foiSalvo = await _generico.SalvarMudancasAsync();
                if(!foiSalvo) throw new Exception("Erro ao deletar evento.");
                return foiSalvo;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Evento> PegaEventoPorIDAsync(int id, bool incluirPalestrantes = false)
        {
            var evento = await _evento.PegaEventoPorIDAsync(id, incluirPalestrantes);
            if(evento == null) throw new NullReferenceException("Evento não existe!");
            return evento;
        }
        public async Task<Evento[]> PegaEventosPorTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            var evento = await _evento.PegaEventosPorTemaAsync(tema, incluirPalestrantes);
            if(evento == null) throw new NullReferenceException("Evento não existe!");
            return evento;
        }
        public async Task<Evento[]> PegaTodosEventosAsync(bool incluirPalestrantes = false)
        { 
            var eventos = await _evento.PegaTodosEventosAsync(incluirPalestrantes);
            if(eventos == null) throw new NullReferenceException("Nenhum evento encontrado!");
            return eventos;
        }
    }
}