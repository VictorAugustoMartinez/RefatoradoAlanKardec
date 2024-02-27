using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NVAlanKardec.Api.Data;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api.Repositories
{
    public class AdmRepositorio : IAdmRepositorio
    {
        private readonly IMongoCollection<Adm> _colecaoAdm;

        public AdmRepositorio(IOptions<ConfiguracaoMongo> mongoConfig)
        {
            MongoClient client = new MongoClient(mongoConfig.Value.ConecaoURI);
            IMongoDatabase database = client.GetDatabase(mongoConfig.Value.DbNome);
            _colecaoAdm = database.GetCollection<Adm>(mongoConfig.Value.ColecaoAdm);
        }

        public async Task Adicionar(Adm entidade)
        {
            await _colecaoAdm.InsertOneAsync(entidade);
            return;
        }

        public async Task Atualizar(Adm model)
        {
            var filtro = Builders<Adm>.Filter.Eq("Id", model.Id);
            await _colecaoAdm.ReplaceOneAsync(filtro, model, new ReplaceOptions { IsUpsert = true });
            return;
        }

        public async Task Deletar(string id)
        {
            FilterDefinition<Adm> filter = Builders<Adm>.Filter.Eq("Id", id);
            await _colecaoAdm.DeleteOneAsync(filter);
            return;
        }

        public async Task<IEnumerable<Adm>> ObterTodos()
        {
            var results = await _colecaoAdm.FindAsync(_ => true);
            return await results.ToListAsync();
        }

        public async Task<List<Adm>> ObterPorId(string id)
        {
            FilterDefinition<Adm> filter = Builders<Adm>.Filter.Eq("Id", id);
            return await _colecaoAdm.Find(filter).ToListAsync();

        }
    }
}
