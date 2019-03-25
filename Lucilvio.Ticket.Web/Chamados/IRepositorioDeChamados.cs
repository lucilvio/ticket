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
        private IContexto _contexto;

        public RepositorioDeChamadosEmMemoria(IContexto contexto)
        {
            this._contexto = contexto;
        }

        public void Adicionar(Chamado novoChamado)
        {
            this._contexto.Chamados.Add(new DadosDoChamado { Protocolo = novoChamado.Protocolo, Descricao = novoChamado.Descricao });
        }

        public IReadOnlyList<DadosDoChamado> Listar()
        {
            return this._contexto.Chamados.ToList();
        }

        public int PegarUltimoProtocolo()
        {
            var protocolo = this._contexto.Chamados.OrderByDescending(c => c.DataDeAbertura).Select(c => c.Protocolo).FirstOrDefault();
            return !string.IsNullOrEmpty(protocolo) ? int.Parse(protocolo) : 0;
        }
    }
}