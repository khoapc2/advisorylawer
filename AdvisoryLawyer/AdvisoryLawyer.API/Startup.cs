using AdvisoryLawyer.Business.AutoMapper;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Services;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AdvisoryLawyer.Data.Repositories;
using BookingLawyer.Business.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdvisoryLawyer.API
{
    public class Startup
    {
        private readonly string _corsName = "AdvisoryLawyer";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var path = Directory.GetCurrentDirectory();
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile($"{path}\\Firebase\\firebase-config.json"),
            });

            services.AddCors(option =>
            {
                option.AddPolicy(name: _corsName,
                                    builder =>
                                    {
                                        builder.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
               option.Authority = Configuration["Jwt:Authority"];
               option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,                     
                    ValidateAudience = true,                    
                    ValidateLifetime = true,                    
                    //ValidateIssuerSigningKey = true,            
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            var connectionString = Configuration.GetConnectionString("AdvisoryConnectionString");
            services.AddDbContext<AdvisoryLawyerContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(AdvisoryModule).Assembly);

            services.AddScoped<IAdvisoryService, AdvisoryService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<ICaseItemService, CaseItemService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<ICustomerCaseService, CustomerCaseService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddScoped<AdvisoryLawyerContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdvisoryLawyer.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });
            
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //var path = Directory.GetCurrentDirectory();
            //loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdvisoryLawyer.API v1"));
                app.UseSwaggerUI(c => {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "AdvisoryLawyer.API");
                });
            }

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseCors(_corsName);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
