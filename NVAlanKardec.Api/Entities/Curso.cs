using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using NVAlanKardec.Api.Entities.Interfaces;

namespace NVAlanKardec.Api.Entities
{
    public class Curso : ICurso
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Materia { get; set; }
        public string Descricao { get; set; }
        public string DataInicio { get; set; }
        public string Turma { get; set; }
        public Professor Proprietario { get; set; }
    }

}
