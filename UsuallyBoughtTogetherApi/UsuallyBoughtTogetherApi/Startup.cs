﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.OpenApi.Models;
using UsuallyBoughtTogetherApi.Constants;
using UsuallyBoughtTogetherApi.Repositories;
using UsuallyBoughtTogetherApi.Services;

namespace UsuallyBoughtTogetherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adding and configuring DBContext
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            switch (environmentName)
            {
                case null:
                    throw new ArgumentNullException(environmentName, "Cannot use the name of the environment, because it is NULL");
                case EnvironmentConstants.Production:
                case EnvironmentConstants.Preprod:
                case EnvironmentConstants.Test:
                {
                    var connectionString = Environment.GetEnvironmentVariable("UBTA_DB_CONNECTIONSTRING");
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new Exception(
                            "Environmentvariable: UBTA_DB_CONNECTIONSTRING was not set. There is no connectionstring to the database for this application to use.");
                    }
                    services.AddDbContext<PredictionContext>(options => options
                        .UseSqlServer(connectionString)
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
                    break;
                }

                case EnvironmentConstants.Development:
                    services.AddDbContext<PredictionContext>(options => options.UseSqlite("Data Source=prediction.db"));
                    break;
                case EnvironmentConstants.AutomatedTesting:
                    // Dont do anything, dbcontext is created in test-setup
                    break;
                default:
                    // Fail by default
                    throw new Exception($"Environment is:{environmentName}. Environment not supported.");
            }
            

            services.AddMvc();

            // Setting up and configuring swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Usually Bought Togheter HTTP-REST API", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            // 
            services.AddControllers();

            // Dependecy injection (Transient)
            services.AddTransient<IPredictionService, PredictionService>();
            services.AddTransient<IProductEntryDataRepo, ProductEntryDataRepo>();

            // Dependency injection (singleton)
            services.AddSingleton<MLContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Do migrations if any
            
            
            // swagger endpoint
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "UBTA V1"); });

            //app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}