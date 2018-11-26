using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Training.Models;
using Training.Authentication;
using Training.Authentication.ImapAuth;
using Training.Authentication.MyAuth;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Training.Processors.Business;
using Training.Processors;
using Training.ErrorHandling;

namespace Training
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            string cfgName = env.IsDevelopment() ? $"appsettings.{env.EnvironmentName}.json" : "appsettings.json";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile(Path.Join(Directory.GetCurrentDirectory(), cfgName), optional: false, reloadOnChange: true)
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            // ---------- Logger service -----------
            // https://stackoverflow.com/questions/46169606/how-to-use-log4net-in-asp-net-core-2-0
            var svc = new ServiceCollection()
                .AddLogging(logBuilder => logBuilder.SetMinimumLevel(LogLevel.Trace))
                .BuildServiceProvider();
            var logger = svc.GetService<ILoggerFactory>()
                .AddLog4Net()
                .CreateLogger<Program>();
            services.AddSingleton<ILogger>(logger);
            // -------------------------------------
            
            // ------ Authentication types ------
            IMyAuth auth = null;
            switch (Configuration["Authentication:Via"].ToLower())
            {
                case "imap":
                    {
                        auth = new ImapAuth(Configuration);
                        break;
                    }
            }
            if (auth != null) { services.AddSingleton<IMyAuth>(auth); }
            // ----------------------------------

            // -------- Bearer Authentication preparation ------
            // https://www.c-sharpcorner.com/article/asp-net-core-2-0-bearer-authentication/
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options => {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.Events = new JwtBearerEvents
                  {
                      OnAuthenticationFailed = context =>
                      {
                          Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                          return Task.CompletedTask;
                      },
                      OnTokenValidated = context =>
                      {
                          Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                          return Task.CompletedTask;
                      }
                  };
                  options.TokenValidationParameters =
                       new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,

                           ValidIssuer = Configuration["Jwt:Issuer"],
                           ValidAudience = Configuration["Jwt:Audience"],
                           IssuerSigningKey = JwtSecurityKey.Create(Configuration["Jwt:Secret"]) // In Production it MUST BE in Environment variable. Like that: Environment.GetEnvironmentVariable("JWT_KEY");
                       };
              });
            // -----------------------------------------------

            // ---------- Database ---------------
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration["Data:Training:ConnectionString"]));
            services.AddTransient<ITrainingRepository, EFTrainingRepository>();
            // -----------------------------------
            services.AddAutoMapper();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // ----------- Query Processors ---------------
            services.AddSingleton<IGetTrainingProcessor, GetTrainingProcessor>();
            // ----------- Business Processors ------------
            services.AddSingleton<IGetTrainingBusiness, GetTrainingBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware(typeof(ErrorHandlingMiddleware));
                app.UseHttpsRedirection();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            // Initiate Data if they are don't exist
            InitialData.EnsureInitiated(app);
        }
    }
}
