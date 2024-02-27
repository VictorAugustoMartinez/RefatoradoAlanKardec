namespace NVAlanKardec.Api.Entities.Interfaces
{
    public interface IUsuarioBase
    {
        string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataCadastro { get; set; }
    }
}
