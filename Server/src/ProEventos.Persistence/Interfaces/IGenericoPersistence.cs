namespace ProEventos.Persistence.Interfaces
{
    public interface IGenericoPersistence
    {
        void Adicionar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Deletar<T>(T entity) where T : class;
        void DeletarVarios<T>(T entity) where T : class;

        Task<bool> SalvarMudancasAsync();
    }
}