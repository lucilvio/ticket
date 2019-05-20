using System;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    public sealed class Protocolo
    {
        private readonly int _valor;

        public Protocolo(int valor)
        {
            if (valor <= 0)
                throw new NumeroDoProtocoloNaoPodeSerIgualOuMenorQueZero();

            this._valor = valor;
        }

        public int Valor => this._valor;

        public static implicit operator int(Protocolo protocolo)
        {
            return protocolo.Valor;
        }
    }
}