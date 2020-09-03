using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using InvestmentOptionCalculator.Api.Libs.CurrencyRate;
using InvestmentOptionCalculator.Api.ModelMappers;
using InvestmentOptionCalculator.Api.Services;
using InvestmentOptionCalculator.Api.Strategies.InvestmentOption;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InvestmentOptionCalculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient();

            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Investment Option Calculator - API",
                    Version = "v1",
                    Description = "Investment Option Calculator - Admin"
                });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var baseDirectory = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                // Enable Annotations
                c.EnableAnnotations();
            });
            //add newton support for swagger
            services.AddSwaggerGenNewtonsoftSupport();

            //fluent validation
            var assembly = Assembly.GetAssembly(typeof(Startup));
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly)).AddNewtonsoftJson();

            services.AddControllers();

            //app services
            services.AddTransient<ICurrencyRateService, CurrencyRateService>();
            services.AddTransient<ICurrencyConversionService, CurrencyConversionService>();
            services.AddScoped<IInvestmentOptionService, InvestmentOptionService>();    //currently no db invloved, this is for future proof
            services.AddScoped<IInvestmentOptionMapper, InvestmentOptionMapper>();
            services.AddSingleton<ICalculationStrategyFactory, CalculationStrategyFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(o =>
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(o =>
            {
                o.DocumentTitle = "Swagger UI - Investment Option Calculator";
                o.SwaggerEndpoint("/docs/v1/docs.json", "Investment Option Calculator - API");
                o.RoutePrefix = "docs";
                o.DisplayOperationId();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
