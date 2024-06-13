using Microsoft.EntityFrameworkCore;
using Variant1.Core;
using Variant1.DAL.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDAL();
builder.Services.AddCore();
builder.Services.AddDbContext<EfContext>
    (options => options.UseNpgsql(builder.Configuration["ConnectionString_Postgres_Dev"]));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await migrator.MigrateAsync(new CancellationToken());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();