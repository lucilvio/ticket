using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Dominio.Operadores
{
    [Serializable]
    internal class OperadorJaEstaAtivo : ExcecaoDeNegocio
    {
        public OperadorJaEstaAtivo()
        {
        }
    }
}