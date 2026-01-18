using Microsoft.EntityFrameworkCore;
using Q5;
using Q5.DAO;
using Q5.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IContaDAO, ContaDAO>(); 
builder.Services.AddScoped<IContaService, ContaService>(); 

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql("Host=localhost;Database=TesteBackEnd;Username=postgres;Password=123456");
});
var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();