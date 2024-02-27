namespace NVAlanKardec.Api.Entities
{
    public class Professor : UsuarioBase
    {
        public List<Curso> Cursos { get; set; }
    }
}
