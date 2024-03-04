using RobotApi.Interfaces.Repository;
using RobotApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IRobotRepository, RobotRepository>();

var configuration = builder.Configuration;
builder.Services.AddNpgsqlDataSource(configuration.GetConnectionString("RobotDb")!, ServiceLifetime.Singleton);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
