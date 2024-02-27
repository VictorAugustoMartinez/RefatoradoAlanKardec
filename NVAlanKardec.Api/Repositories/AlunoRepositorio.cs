using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NVAlanKardec.Api.Data;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Repositories
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly IMongoCollection<Aluno> _colecaoAluno;

        public AlunoRepositorio(IOptions<ConfiguracaoMongo> mongoConfig)
        {
            MongoClient client = new MongoClient(mongoConfig.Value.ConecaoURI);
            IMongoDatabase database = client.GetDatabase(mongoConfig.Value.DbNome);
            _colecaoAluno = database.GetCollection<Aluno>(mongoConfig.Value.ColecaoAluno);
        }

        public async Task Adicionar(Aluno entidade)
        {
            await _colecaoAluno.InsertOneAsync(entidade);
            return;
        }

        public async Task Atualizar(Aluno model)
        {
            var filtro = Builders<Aluno>.Filter.Eq("Id", model.Id);
            await _colecaoAluno.ReplaceOneAsync(filtro, model, new ReplaceOptions { IsUpsert = true });
            return;
        }

        public async Task Deletar(string id)
        {
            FilterDefinition<Aluno> filter = Builders<Aluno>.Filter.Eq("Id", id);
            await _colecaoAluno.DeleteOneAsync(filter);
            return;
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            var results = await _colecaoAluno.FindAsync(_ => true);
            return await results.ToListAsync();
        }

        public async Task<List<Aluno>> ObterPorId(string id)
        {
            FilterDefinition<Aluno> filter = Builders<Aluno>.Filter.Eq("Id", id);
            return await _colecaoAluno.Find(filter).ToListAsync();

        }
    }
}
