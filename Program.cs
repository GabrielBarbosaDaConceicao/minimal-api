using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.Servicos;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

        builder.Services.AddDbContext<DbContexto>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("mysql"),
                ServerVersion.AutoDetect("mysql")));

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
        {
            if (administradorServico.Login(loginDTO) != null)
            {
                return Results.Ok("Login com sucesso");
            }
            else
            {
                return Results.Unauthorized();
            }
        });

        app.Run();
    }
}

public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
}
