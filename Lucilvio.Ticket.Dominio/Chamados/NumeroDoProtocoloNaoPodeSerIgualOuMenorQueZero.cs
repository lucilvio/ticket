using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    [Serializable]
    internal class NumeroDoProtocoloNaoPodeSerIgualOuMenorQueZero : Exception
    {
        public NumeroDoProtocoloNaoPodeSerIgualOuMenorQueZero()
        {
        }

        public NumeroDoProtocoloNaoPodeSerIgualOuMenorQueZero(string message) : base(message)
        {
        }

        public NumeroDoProtocoloNaoPodeSerIgualOuMenorQueZero(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumeroDoProtocoloNaoPodeSerIgualOuMenorQueZero(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}