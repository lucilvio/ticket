using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucilvio.Ticket.Web.Chamados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lucilvio.Ticket.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<RazorViewEngineOptions>(ro =>
            {
                ro.ViewLocationFormats.Add("/{1}/{0}/{0}" + RazorViewEngine.ViewExtension);
                ro.ViewLocationFormats.Add("/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IContexto, ContextoEmMemoria>();

            services.AddSingleton<IRepositorioDeChamados>(provider =>
            {
                return new RepositorioDeChamadosEmMemoria(provider.GetService<IContexto>());
            });

            services.AddSingleton<IRepositorioDeClientes>(provider =>
            {
                return new RepositorioDeClientesEmMemoria(provider.GetService<IContexto>());
            });

            services.AddScoped<IBuscaDeChamados>(provider =>
            {
                return new BuscaDeChamados(provider.GetService<IContexto>());
            });

            services.AddTransient<IAdaptadorDeCliente, AdaptadorDeCliente>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
