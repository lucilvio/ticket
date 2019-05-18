using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lucilvio.Ticket.Buscas;
using Lucilvio.Ticket.Infra.RepositoriosEf;
using Lucilvio.Ticket.Infra.SegurancaPorCookie;
using Lucilvio.Ticket.Servicos;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao;
using Lucilvio.Ticket.Web.Autorizacao;
using Lucilvio.Ticket.Web.Chamados;
using Lucilvio.Ticket.Web.Filtros;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
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
            services.AddSession();
            services.AddHttpContextAccessor();
            
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

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opcoes =>
            { 
                opcoes.LoginPath = "/Login";
            });

            services.AddAuthorization(opt =>
            {
                ConfiguracaoDePoliticas.Configurar(opt);
            });

            services.AddMvc(opc =>
            {
                opc.Filters.Add(new AuthorizeFilter());
                opc.Filters.Add(new TratarExcecoesDeNegocio());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<Contexto>(opt =>
            {
                opt.UseSqlServer(@"Server=localhost;Database=lucilvio.ticket;Trusted_Connection=True;MultipleActiveResultSets=true;Connection Timeout=300;");
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            var tiposDoAssemblyDeBuscas = typeof(IQuery).Assembly.GetTypes();
            var tiposDoAssemblyDeServico = typeof(IServico<>).Assembly.GetTypes();

            this.InjetarRepositorios(services, tiposDoAssemblyDeServico);
            this.InjetarBuscas(services, tiposDoAssemblyDeBuscas);
            this.InjetarServicosExternos(services);
            this.InjetarComandos(services, tiposDoAssemblyDeServico);

            services.AddSingleton<IServicos>(provider =>
            {
                return new FabricaDeServicos(provider);
            });
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

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseMvc();
        }

        private void InjetarComandos(IServiceCollection services, IEnumerable<Type> tipos)
        {
            var tiposDeComandos = tipos
                .Where(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i == typeof(IComando))).ToList();

            IList<Type> tiposDeServicos = new List<Type>();

            tiposDeComandos.ForEach(t => tiposDeServicos.Add(tipos
                .FirstOrDefault(ty => ((TypeInfo)ty).ImplementedInterfaces.Any(i => i.GenericTypeArguments.Contains(t)))));

            tiposDeServicos.ToList().ForEach(t => services.AddTransient(t));
        }

        private void InjetarServicosExternos(IServiceCollection services)
        {
            services.AddTransient<IServicoDeAutenticacao>(p =>
            {
                return new ServicoDeAutenticacaoViaCookie(p.GetService<IHttpContextAccessor>().HttpContext);
            });
        }

        private void InjetarBuscas(IServiceCollection services, IEnumerable<Type> tipos)
        {
            var tiposDeQueries = tipos
                .Where(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i == typeof(IQuery))).ToList();

            IList<Type> tiposDeBuscas = new List<Type>();
            var implementacoesDeBuscas = new Dictionary<Type, Type>();

            tiposDeQueries.ForEach(t => tiposDeBuscas.Add(
                tipos.FirstOrDefault(ty => ((TypeInfo)ty).ImplementedInterfaces.Any(i => i.GenericTypeArguments.Contains(t)))));

            tiposDeBuscas.Where(tb => tb != null).ToList().ForEach(t => implementacoesDeBuscas.Add(t, typeof(Contexto).Assembly.GetTypes()
               .FirstOrDefault(ty => ((TypeInfo)ty).ImplementedInterfaces.Any(i => i == t))));

            implementacoesDeBuscas.ToList().Where(i => i.Value != null).ToList().ForEach(t => services.AddTransient(t.Key, t.Value));
        }

        private void InjetarRepositorios(IServiceCollection services, IEnumerable<Type> tipos)
        {
            var tiposDeRepositorios = tipos
                .Where(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i == typeof(IRepositorio))).ToList();

            var implementacoesDosRepositorios = new Dictionary<Type, Type>();

            tiposDeRepositorios.Where(tr => tr != null).ToList().ForEach(t => implementacoesDosRepositorios.Add(t, typeof(Contexto).Assembly.GetTypes()
               .FirstOrDefault(ty => ((TypeInfo)ty).ImplementedInterfaces.Any(i => i == t))));

            implementacoesDosRepositorios.Where(i => i.Value != null).ToList().ForEach(t => services.AddTransient(t.Key, t.Value));
        }
    }
}