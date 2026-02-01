using Seyid.Api.Middlewares;
using Seyid.Business.ServiceRegistrations;
using Seyid.DataAccess.ServiceRegistrations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Seyid.DataAccess.Abstractions;
public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDataAccessServices(builder.Configuration);

        builder.Services.AddBusinessServices(builder.Configuration);

        var app = builder.Build();

        var scope = app.Services.CreateScope();
        var initalizer = scope.ServiceProvider.GetRequiredService<IContextInitalizer>();
        await initalizer.InitDatabaseAsync();

        if (!app.Environment.IsDevelopment())
            app.UseMiddleware<GlobalExceptionHandler>();

        app.UseCors("MyPolicy");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(); 
            app.UseSwaggerUI(); 
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}