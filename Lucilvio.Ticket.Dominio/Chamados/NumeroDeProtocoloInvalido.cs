using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    [Serializable]
    internal class NumeroDeProtocoloInvalido : Exception
    {
        public NumeroDeProtocoloInvalido()
        {
        }

        public NumeroDeProtocoloInvalido(string message) : base(message)
        {
        }

        public NumeroDeProtocoloInvalido(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumeroDeProtocoloInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}