using NVAlanKardec.Api.Entities;

namespace NVAlanKardec.Api.Repositories.interfaces
{
    public interface ICursoRepositorio
    {
        Task<IEnumerable<Curso>> ObterTodos();
        Task<List<Curso>> ObterPorId(string id);
        Task Adicionar(Curso entidade);
        Task Deletar(string id);
        Task Atualizar(Curso entidade);
    }
}
