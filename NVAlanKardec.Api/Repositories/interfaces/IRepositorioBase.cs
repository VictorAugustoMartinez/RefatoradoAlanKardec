using NVAlanKardec.Api.Entities;

namespace NVAlanKardec.Api.Repositories.interfaces
{
    public interface IRepositorioBase<T> where T : UsuarioBase
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<List<T>> ObterPorId(string id);
        Task Adicionar(T entidade);
        Task Deletar(string id);
        Task Atualizar(T entidade);
    }
}
