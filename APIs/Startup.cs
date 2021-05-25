using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Services;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.IO;
using SharedConfig.Config;
using APIs.Utilities;
using Serilog;
using SharedConfig.Middlewares.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using APIs.Jobs;
using Quartz.Spi;
using RechargeAutoAction.Jobs.ManageRechargeCases;
using Quartz;
using Quartz.Impl;
using System.Reflection;

namespace WebApplication2
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        private AppConfig _config;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetAppSettingsFile();

            _config = Configuration.Get<AppConfig>();

            services.AddAutoMapper(typeof(Startup));
            
            services.AddControllers();
            services.AddSingleton(_config);
            services.AddSingleton<ICustomLoggingConfig, CustomLoggingConfig>();
            services.RegisterDataAccessLayer(_config.DBConfig.ConnectionString);
            services.RegisterServiceLayer();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config.JWTConfig.ValidAudience,
                    ValidAudience = _config.JWTConfig.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.JWTConfig.Secret))
                };
            });

            // Disable automatic model validation
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc()
            .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Template",
                    Description = "Swagger Documentation",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Karim Alaa",
                        Email = "karim.elzarkany@te.eg",
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                options.EnableAnnotations();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            // Add Quartz services
            services.AddTransient<IJobFactory, SingletonJobFactory>();
            services.AddTransient<ISchedulerFactory, StdSchedulerFactory>();

            // Add HostedService
            services.AddHostedService<QuartzHostedService>();

            // Add our jobs
            services.AddTransient <StayAliveJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(StayAliveJob),
                cronExpression: "0 0/15 * 1/1 * ? *"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ICustomLoggingConfig customLoggingConfig)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            // Global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.Use(async (context, next) => {
                context.Request.EnableBuffering();
                await next();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            // Logging and debugging
            app.UseMiddleware<RequestLoggingMiddleware>();

            // setup custom logging
            Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(
              connectionString: _config.CustomLogging.WriteTo.FirstOrDefault().Args.ConnectionString,
              sinkOptions: customLoggingConfig.GetSinkOpts(),
              columnOptions: customLoggingConfig.GetColumnOptions())
            .MinimumLevel.Information()
            .Enrich.WithMachineName()
            .CreateLogger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Add appsettings files
        private void SetAppSettingsFile()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddJsonFile($"appsettings.{env}.json", true, true);
            Configuration = builder.Build();
        }
    }
}
