using Lucilvio.Ticket.Buscas.ListarChamados;
using Lucilvio.Ticket.Buscas.ListarClientes;
using Lucilvio.Ticket.Buscas.ListarOperadores;
using Lucilvio.Ticket.Buscas.PegarChamadoPeloProtocolo;
using Lucilvio.Ticket.Infra.RepositoriosEf;
using Lucilvio.Ticket.Infra.RepositoriosEf.ListarChamados;
using Lucilvio.Ticket.Infra.RepositoriosEf.ListarClientes;
using Lucilvio.Ticket.Infra.RepositoriosEf.ListarOperadores;
using Lucilvio.Ticket.Infra.RepositoriosEf.PegarChamadoPorProtocolo;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaAberturaDeChamado;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeCliente;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaCadastroDeOperador;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaEntrarNoSistema;
using Lucilvio.Ticket.Infra.RepositoriosEf.RepositorioParaResponderChamado;
using Lucilvio.Ticket.Infra.SegurancaPorCookie;
using Lucilvio.Ticket.Servicos.AbrirChamado;
using Lucilvio.Ticket.Servicos.CadastrarCliente;
using Lucilvio.Ticket.Servicos.CadastrarOperador;
using Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Autenticacao;
using Lucilvio.Ticket.Servicos.EntrarNoSistema;
using Lucilvio.Ticket.Servicos.EntrarNoSistemaComoCliente;
using Lucilvio.Ticket.Servicos.ResponderChamado;
using Lucilvio.Ticket.Servicos.SairDoSistema;
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
                opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=lucilvio.ticket;Trusted_Connection=True;MultipleActiveResultSets=true;Connection Timeout=300;");
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddTransient<IRepositorioParaAberturaDeChamado, RepositorioParaAberturaDeChamado>();
            services.AddTransient<IRepositorioParaResponderChamado, RepositorioParaResponderChamado>();
            services.AddTransient<IRepositorioParaCadastroDeOperador, RepositorioParaCadastroDeOperador>();
            services.AddTransient<IRepositorioParaEntradaNoSistema, RepositorioParaEntrarNoSistema>();
            services.AddTransient<IRepositorioParaCadastroDeCliente, RepositorioParaCadastroDeCliente>();


            services.AddTransient<IListarChamados, ListarChamados>();
            services.AddTransient<IListarOperadores, ListarOperadores>();
            services.AddTransient<IListarClientes, ListarClientes>();
            services.AddTransient<IPegarChamadoPorProtocolo, PegarChamadoPorProtocolo>();

            services.AddTransient<IServicoDeAutenticacao>(p =>
            {
                return new ServicoDeAutenticacaoViaCookie(p.GetService<IHttpContextAccessor>().HttpContext);
            });

            services.AddTransient<EntrarNoSistema>();
            services.AddTransient<EntrarNoSistemaComoCliente>();
            services.AddTransient<SairDoSistema>();
            services.AddTransient<AbrirChamado>();
            services.AddTransient<ResponderChamado>();
            services.AddTransient<CadastrarOperador>();
            services.AddTransient<CadastrarCliente>();

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
    }
}