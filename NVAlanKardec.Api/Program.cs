using NVAlanKardec.Api.Data;
using NVAlanKardec.Api.Entities;
using NVAlanKardec.Api.Repositories;
using NVAlanKardec.Api.Repositories.interfaces;

namespace NVAlanKardec.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<ConfiguracaoMongo>(builder.Configuration.GetSection("MongoDB"));
            builder.Services.AddSingleton<ConfiguracaoMongo>();
            builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            builder.Services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
            builder.Services.AddScoped<IAdmRepositorio, AdmRepositorio>();
            builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                Console.WriteLine("Desenvolvimento");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
