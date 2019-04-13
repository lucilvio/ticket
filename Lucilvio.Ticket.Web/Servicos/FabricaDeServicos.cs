using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lucilvio.Ticket.Buscas;
using Lucilvio.Ticket.Servicos;

namespace Lucilvio.Ticket.Web.Chamados
{
    public class FabricaDeServicos : IServicos
    {
        private readonly IServiceProvider _container;

        public FabricaDeServicos(IServiceProvider container)
        {
            this._container = container;
        }

        public async Task Enviar(IComando comando)
        {
            var tipoDoServico = comando.GetType().Assembly.GetTypes()
                .FirstOrDefault(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i.GenericTypeArguments.Contains(comando.GetType())));
            
            dynamic servico = this._container.GetService(tipoDoServico);
            await servico.Executar((dynamic)comando);
        }

        public dynamic EnviarQuery(IQuery query)
        {
            var tipoDaBusca = query.GetType().Assembly.GetTypes()
                .FirstOrDefault(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i.GenericTypeArguments.Contains(query.GetType())));

            dynamic busca = this._container.GetService(tipoDaBusca);
            return busca.Executar((dynamic)query);
        }
    }
}