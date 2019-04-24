using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Dominio.Operadores
{
    [Serializable]
    internal class OperadaroJaEstaInativo : ExcecaoDeNegocio
    {
        public OperadaroJaEstaInativo()
        {
        }
    }
}