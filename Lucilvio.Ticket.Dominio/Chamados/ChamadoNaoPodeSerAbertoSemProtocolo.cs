using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    [Serializable]
    internal class ChamadoNaoPodeSerAbertoSemProtocolo : ExcecaoDeNegocio
    {
        public ChamadoNaoPodeSerAbertoSemProtocolo()
        {
        }
    }
}