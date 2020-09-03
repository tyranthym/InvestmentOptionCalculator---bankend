using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
