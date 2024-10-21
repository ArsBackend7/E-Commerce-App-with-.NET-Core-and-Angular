using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repositories.Implementations;
using Server.Repositories.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// AddEntity services to the container.
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("DCS")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
