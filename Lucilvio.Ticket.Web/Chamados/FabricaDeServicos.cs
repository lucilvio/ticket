using System;
using System.Linq;
using System.Reflection;

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
            var nomeDoComando = comando.GetType().Name;
            var tipoDoServico = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.Contains(nomeDoComando.Replace("ComandoPara", "")));
            
            dynamic servico = this._container.GetService(tipoDoServico);
            servico.Executar((dynamic)comando);
        }

        public dynamic EnviarQuery(IQuery query)
        {
            var nomeDaQuery = query.GetType().Name;
            var tipoDaBusca = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.Contains(nomeDaQuery.Replace("QueryPara", "")));

            dynamic busca = this._container.GetService(tipoDaBusca);
            return busca.Executar((dynamic)query);
        }
    }
}