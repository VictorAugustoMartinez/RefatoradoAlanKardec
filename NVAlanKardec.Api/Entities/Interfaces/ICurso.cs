namespace NVAlanKardec.Api.Entities.Interfaces
{
    public interface ICurso
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Materia { get; set; }
        public string Descricao { get; set; }
        public string DataInicio { get; set; }
        public string Turma { get; set; }
        public Professor Proprietario { get; set; }
    }
}
