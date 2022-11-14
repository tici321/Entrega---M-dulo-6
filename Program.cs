using GOTRAVEL.DataBase;
using GOTRAVEL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionMySql = builder.Configuration
.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UsuarioDbContext>(
    options => options.UseMySql(connectionMySql,
    ServerVersion.Parse("8.0.30-mysql"))
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
