using Seyid.Business.ServiceRegistrations;
using Seyid.DataAccess.ServiceRegistrations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables middleware to serve generated Swagger as a JSON endpoint
    app.UseSwaggerUI(); // Enables middleware to serve swagger-ui (HTML, JS, CSS, etc.)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
