using System;
using System.IO;
using System.Text;
using App.Domain.Handlers;
using App.Domain.Repositories;
using App.Domain.Services;
using App.Infra.Context;
using App.Infra.Repositories;
using App.Infra.Services;
using App.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace App.Api
{
    public class Startup
    {
        private const string Issuer = "c1f51f42";
        private const string Audience = "c6bbbb645024";
        private const string Secret_Key = "c1f51f42-5588-gh77-yu7t-c6bbbb645024";
        public static IConfiguration Configuration { get; set; }
        private readonly SymmetricSecurityKey _siginkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret_Key));
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json");

            Configuration = builder.Build();

            services.AddMvc(config =>
            {
                var Policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(Policy));
            });

            services.AddCors();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User",policy=>policy.RequireClaim("Apptest","User"));
                options.AddPolicy("Admin",policy=>policy.RequireClaim("AppTest","Admin"));
            });

            services.Configure<Security.TokenOptions>(options =>
            {
                options.Issuer = Issuer;
                options.Audience = Audience;
                options.SigningCredentials = new SigningCredentials(_siginkey,SecurityAlgorithms.HmacSha256);
            });
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Issuer,

                ValidateAudience = true,
                ValidAudience = Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _siginkey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options=>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddResponseCompression();


            services.AddScoped<AppDataContext, AppDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<CustomerCommandHandler,CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandler,OrderCommandHandler>();
            services.AddTransient<IEmailService,EmailService>();

            ConnectionSettings.ConnectionString = Configuration["connectionString"];
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors(x=>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseMvc();

            app.UseResponseCompression();
        }
    }
}
