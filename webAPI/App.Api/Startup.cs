using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using App.BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace App.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                // ...
                //var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Api.xml");
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                var commentsFileName = "Api" + ".XML";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                c.IncludeXmlComments(commentsFile);
                //c.IncludeXmlComments(filePath);

                //c.TagActionsBy(api => api.RelativePath.Split('/')[1]); //依據第一個route群組
                //c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");//依據HttpMethod排序



                c.SwaggerDoc(
                      // name: 攸關 SwaggerDocument 的 URL 位置。
                      name: "v1",
                      // info: 是用於 SwaggerDocument 版本資訊的顯示(內容非必填)。
                      info: new OpenApiInfo
                      {
                          Title = "API Doc",
                          Version = "1.0.0",
                          Description = "This is ASP.NET Core RESTful API Sample.",
                          //TermsOfService = "None",
                          //Contact = new Contact
                          //{
                          //    Name = "John Wu",
                          //    Url = "https://blog.johnwu.cc"
                          //},
                          //License = new License
                          //{
                          //    Name = "CC BY-NC-SA 4.0",
                          //    Url = "https://creativecommons.org/licenses/by-nc-sa/4.0/"
                          //}
                      }
                  );


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityDefinition("reCAPTCHA", new OpenApiSecurityScheme
                {
                    Description =
     "Google ReCaptcha",
                    Name = "reCAPTCHA",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
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

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "reCAPTCHA"
                            },
                            Scheme = "oauth2",
                            Name = "reCAPTCHA",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });


            });


            services.AddScoped<IBase, Base>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IUserGroup, UserGroup>();
            services.AddScoped<IAuthService, App.BLL.AuthService>();
                        services.AddScoped<IApply, Apply>();
//#AutoID
            services.AddScoped<ISample, Sample>();

            //取得IP Accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var aaa = Configuration["AppSettings:VirtualDirectory"];
            if (env.IsDevelopment())
            {
                app.UseCors("CorsPolicy");
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    // url: 需配合 SwaggerDoc 的 name。 "/swagger/{SwaggerDoc name}/swagger.json"
                    url: Configuration["AppSettings:VirtualDirectory"] + "/swagger/v1/swagger.json",
                    // description: 用於 Swagger UI 右上角選擇不同版本的 SwaggerDocument 顯示名稱使用。
                    name: "App.Api"
                );

            });

            app.UseHttpsRedirection();

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
