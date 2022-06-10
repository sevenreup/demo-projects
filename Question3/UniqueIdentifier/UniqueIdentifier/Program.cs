using Microsoft.EntityFrameworkCore;
using UniqueIdentifier;
using UniqueIdentifier.Data;
using UniqueIdentifier.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<IdentifierContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase(3);

app.UseAuthorization();

app.MapControllers();

app.Run();
