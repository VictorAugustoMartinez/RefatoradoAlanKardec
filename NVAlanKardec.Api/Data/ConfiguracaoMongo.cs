namespace NVAlanKardec.Api.Data
{
    public class ConfiguracaoMongo
    {
        public string ConecaoURI { get; set; } = null!;
        public string DbNome { get; set; } = null!;
        public string ColecaoAluno { get; set; } = null!;
        public string ColecaoAdm { get; set; } = null!;
        public string ColecaoProfessor { get; set; } = null!;
        public string ColecaoCurso { get; set; } = null!;
    }
}
