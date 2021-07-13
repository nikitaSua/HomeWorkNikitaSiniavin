using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Asp.Net.Practice_Forms.Data;
using Asp.Net.Practice_Forms.Repositorys;
using Asp.Net.Practice_Forms.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Asp.Net.Practice_Forms.Logger;
using System.IO;
using Microsoft.Extensions.Logging.Debug;

namespace Asp.Net.Practice_Forms
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, EfRepos>();
            services.AddTransient<UserService>();
            services.AddTransient<ToDoTaskService>();

            services.AddControllersWithViews();
            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => //CookieAuthenticationOptions
                    {
                        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                        //LoginPath.Это свойство устанавливает относительный путь, по которому будет перенаправляться анонимный пользователь при доступе к ресурсам, для которых нужна аутентификация.
                    });

            services.AddDbContext<MvcDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MvcDBContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
                builder.AddProvider(new FileLoggerProvider(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt")));
                // настройка фильтров
                builder.AddFilter("System", LogLevel.Error)
                        .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Error);
            });
            ILogger logger = loggerFactory.CreateLogger<Startup>();

            app.Use(async (context, next) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);
                await next.Invoke();
            });
            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Checked-By", "Nikita_Syniavin");
                await next.Invoke();    
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //context.Response.Headers.Add("X-Checked-By", "Nikita_Syniavin");
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/hello", async context =>
                {
                    var name = Configuration["RoutingTask:Author:name"];
                    await context.Response.WriteAsync(name);
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
