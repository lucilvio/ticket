using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucilvio.Ticket.Web.Chamados
{
    public interface IBuscaDeChamados
    {
        IReadOnlyList<ChamadoDaLista> Executar();
    }

    internal class BuscaDeChamados : IBuscaDeChamados
    {
        private readonly IContexto _contexto;

        public BuscaDeChamados(IContexto contexto)
        {
            this._contexto = contexto;
        }

        public IReadOnlyList<ChamadoDaLista> Executar()
        {
            return this._contexto.Chamados.Select(c => new ChamadoDaLista
            {
                Cliente = "",
                Descricao = c.Descricao,
                Protocolo = c.Protocolo,
                DataDaAbertura = ""
            }).ToList();
        }
    }

    public class ChamadoDaLista
    {
        public string Protocolo { get; set; }
        public string Descricao { get; set; }
        public string Cliente { get; set; }
        public string DataDaAbertura { get; set; }
    }
}