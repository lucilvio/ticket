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

        public void Enviar(IComando comando)
        {
            dynamic servico = this.PegarServicoPeloComando(comando);
            servico.Executar((dynamic)comando);
        }

        public async Task EnviarAsync(IComando comando)
        {
            dynamic servico = this.PegarServicoPeloComando(comando);

            if(servico.GetType().CustomAttributes.Any())
            {

            }
            else
            {
                await servico.Executar((dynamic)comando);
            }
        }

        public dynamic EnviarQuery(IQuery query)
        {
            var tipoDaBusca = query.GetType().Assembly.GetTypes()
                .FirstOrDefault(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i.GenericTypeArguments.Contains(query.GetType())));

            dynamic busca = this._container.GetService(tipoDaBusca);
            return busca.Executar((dynamic)query);
        }

        private dynamic PegarServicoPeloComando(IComando comando)
        {
            var tipoDoServico = comando.GetType().Assembly.GetTypes()
                .FirstOrDefault(t => ((TypeInfo)t).ImplementedInterfaces.Any(i => i.GenericTypeArguments.Contains(comando.GetType())));

            return this._container.GetService(tipoDoServico);
        }
    }
}