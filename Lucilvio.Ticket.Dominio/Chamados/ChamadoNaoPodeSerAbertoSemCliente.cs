using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    [Serializable]
    internal class ChamadoNaoPodeSerAbertoSemCliente : ExcecaoDeNegocio
    {
        public ChamadoNaoPodeSerAbertoSemCliente()
        {
        }
    }
}