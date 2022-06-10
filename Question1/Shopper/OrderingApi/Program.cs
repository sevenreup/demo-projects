using Microsoft.EntityFrameworkCore;
using OrderingApi;
using OrderingApi.Data;
using OrderingApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<OrderContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MigrateDatabase(3);

app.UseAuthorization();

app.MapControllers();

app.Run();
