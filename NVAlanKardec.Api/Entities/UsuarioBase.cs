using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using NVAlanKardec.Api.Entities.Interfaces;

namespace NVAlanKardec.Api.Entities
{
    public class UsuarioBase : IUsuarioBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataCadastro { get; set; }
    }
}
