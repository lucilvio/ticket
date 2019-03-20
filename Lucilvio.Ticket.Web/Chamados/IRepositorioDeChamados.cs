using System.Linq;
using System.Collections.Generic;
using Lucilvio.Ticket.Testes;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IRepositorioDeChamados
    {
        int PegarUltimoProtocolo();
        void Adicionar(Chamado novoChamado);
        IReadOnlyList<DadosDoChamado> Listar();
    }

    public class RepositorioDeChamadosEmMemoria : IRepositorioDeChamados
    {
        private static IList<DadosDoChamado> _chamados;

        public RepositorioDeChamadosEmMemoria()
        {
            _chamados = new List<DadosDoChamado>();
        }

        public void Adicionar(Chamado novoChamado)
        {
            _chamados.Add(new DadosDoChamado { Protocolo = novoChamado.Protocolo, Descricao = novoChamado.Descricao });
        }

        public IReadOnlyList<DadosDoChamado> Listar()
        {
            return _chamados.ToList();
        }

        public int PegarUltimoProtocolo()
        {
            return _chamados.OrderByDescending(c => c.DataDeAbertura).Select(c => c.Protocolo).FirstOrDefault();
        }
    }
}