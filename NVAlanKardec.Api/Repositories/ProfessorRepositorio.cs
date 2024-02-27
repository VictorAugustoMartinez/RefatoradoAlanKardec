using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NVAlanKardec.Api.Data;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Repositories
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly IMongoCollection<Professor> _colecaoProfessor;

        public ProfessorRepositorio(IOptions<ConfiguracaoMongo> mongoConfig)
        {
            MongoClient client = new MongoClient(mongoConfig.Value.ConecaoURI);
            IMongoDatabase database = client.GetDatabase(mongoConfig.Value.DbNome);
            _colecaoProfessor = database.GetCollection<Professor>(mongoConfig.Value.ColecaoProfessor);
        }

        public async Task Adicionar(Professor entidade)
        {
            await _colecaoProfessor.InsertOneAsync(entidade);
            return;
        }

        public async Task Atualizar(Professor model)
        {
            var filtro = Builders<Professor>.Filter.Eq("Id", model.Id);
            await _colecaoProfessor.ReplaceOneAsync(filtro, model, new ReplaceOptions { IsUpsert = true });
            return;
        }

        public async Task Deletar(string id)
        {
            FilterDefinition<Professor> filter = Builders<Professor>.Filter.Eq("Id", id);
            await _colecaoProfessor.DeleteOneAsync(filter);
            return;
        }

        public async Task<IEnumerable<Professor>> ObterTodos()
        {
            var results = await _colecaoProfessor.FindAsync(_ => true);
            return await results.ToListAsync();
        }

        public async Task<List<Professor>> ObterPorId(string id)
        {
            FilterDefinition<Professor> filter = Builders<Professor>.Filter.Eq("Id", id);
            return await _colecaoProfessor.Find(filter).ToListAsync();

        }
    }
}
