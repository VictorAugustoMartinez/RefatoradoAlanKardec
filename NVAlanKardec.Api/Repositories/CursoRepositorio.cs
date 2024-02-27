using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NVAlanKardec.Api.Data;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Repositories
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly IMongoCollection<Curso> _colecaoCurso;

        public CursoRepositorio(IOptions<ConfiguracaoMongo> mongoConfig)
        {
            MongoClient client = new MongoClient(mongoConfig.Value.ConecaoURI);
            IMongoDatabase database = client.GetDatabase(mongoConfig.Value.DbNome);
            _colecaoCurso = database.GetCollection<Curso>(mongoConfig.Value.ColecaoCurso);
        }
        public async Task Adicionar(Curso entidade)
        {
            await _colecaoCurso.InsertOneAsync(entidade);
            return;
        }

        public async Task Atualizar(Curso model)
        {
            var filtro = Builders<Curso>.Filter.Eq("Id", model.Id);
            await _colecaoCurso.ReplaceOneAsync(filtro, model, new ReplaceOptions { IsUpsert = true });
            return;
        }

        public async Task Deletar(string id)
        {
            FilterDefinition<Curso> filter = Builders<Curso>.Filter.Eq("Id", id);
            await _colecaoCurso.DeleteOneAsync(filter);
            return;
        }

        public async Task<IEnumerable<Curso>> ObterTodos()
        {
            var results = await _colecaoCurso.FindAsync(_ => true);
            return await results.ToListAsync();
        }

        public async Task<List<Curso>> ObterPorId(string id)
        {
            FilterDefinition<Curso> filter = Builders<Curso>.Filter.Eq("Id", id);
            return await _colecaoCurso.Find(filter).ToListAsync();
        }
    }
}
