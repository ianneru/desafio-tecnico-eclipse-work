
using Application.Facades;
using Application.Facades.Interfaces;
using CF.Customer.Infrastructure.Mappers;
using CorrelationId;
using CorrelationId.DependencyInjection;
using Domain.Repositories;
using Domain.Services;
using Domain.Services.Interfaces;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO.Compression;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddProblemDetails();
            builder.Services.AddDefaultCorrelationId(ConfigureCorrelationId());

            builder.Services.AddTransient<IProjetoFacade, ProjetoFacade>();
            builder.Services.AddTransient<ITarefaFacade, TarefaFacade>();
            builder.Services.AddTransient<IProjetoService, ProjetoService>();
            builder.Services.AddTransient<ITarefaService, TarefaService>();
            builder.Services.AddTransient<IProjetoRepository, ProjetoRepository>();
            builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();

            builder.Services.AddAutoMapper(typeof(ProjetoProfile));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    a => { a.MigrationsAssembly("Infrastructure"); });
            });

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

            RunMigration();

            AddExceptionHandler();

            AddSwagger();

            app.UseCorrelationId();

  

            void RunMigration()
            {
                using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

                if (!serviceScope.ServiceProvider.GetRequiredService<DbContext>().Database.GetPendingMigrations().Any())
                {
                    return;
                }

                serviceScope.ServiceProvider.GetRequiredService<DbContext>().Database.Migrate();
            }

            Action<CorrelationIdOptions> ConfigureCorrelationId()
            {
                return options =>
                {
                    options.LogLevelOptions = new CorrelationIdLogLevelOptions
                    {
                        FoundCorrelationIdHeader = LogLevel.Debug,
                        MissingCorrelationIdHeader = LogLevel.Debug
                    };
                };
            }

            Action<IApplicationBuilder> ConfigureExceptionHandler()
            {
                return exceptionHandlerApp =>
                {
                    exceptionHandlerApp.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = "An unexpected internal exception occurred."
                        });
                    });
                };
            }

            void AddExceptionHandler()
            {
                if (app.Environment.IsDevelopment()) return;
                app.UseExceptionHandler(ConfigureExceptionHandler());
            }

            void AddSwagger()
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CF Api"));
            }
        }
    }
}
