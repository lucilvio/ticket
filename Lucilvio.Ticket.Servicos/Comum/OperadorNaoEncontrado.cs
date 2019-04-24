using Lucilvio.Ticket.Dominio;
using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Servicos.Comum
{
    [Serializable]
    internal class OperadorNaoEncontrado : ExcecaoDeNegocio
    {
        public OperadorNaoEncontrado()
        {
        }
    }
}