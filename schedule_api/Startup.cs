using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using schedule_api_core.Interfaces;
using schedule_api_core.Managers;
using schedule_api_core.Validators;
using schedule_api_database;
using schedule_api_database.interfaces;
using schedule_api_database.stores;

namespace schedule_api
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
            services.AddCors();
            services.AddControllers();

#if DEBUG
            services.AddDbContext<MsSqlContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ScheduleDebugContext"),
             b => b.MigrationsAssembly("schedule_api_database"))
            );
#else
            services.AddDbContext<MsSqlContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ScheduleContext")));
#endif

            services.AddHttpClient("gibbonstudio", opt => opt.BaseAddress = new Uri("https://gibbonstudio.somee.com"));
            services.AddTransient<TokenValidator>();
            services.AddTransient<ISettingsManager, SettingsManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseRouting();
           
            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Developed-By", "GibbonStudio");
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
