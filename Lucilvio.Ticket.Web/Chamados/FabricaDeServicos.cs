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
            
            var servico = this._container.GetService(tipoDoServico);

        }
    }
}