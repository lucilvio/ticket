using System;

namespace Lucilvio.Ticket.Dominio.Chamados
{
    public class Protocolo
    {
        private Protocolo(int valor)
        {
            int anoCorrente = DateTime.Now.Year;

            if (valor.ToString().Length > 4)
            {
                this.Ano = int.Parse(valor.ToString().Substring(0, 4));
                this.Incremental = int.Parse(valor.ToString().Substring(4));

                if (anoCorrente > this.Ano)
                    this.Incremental = 0;
            }
            else
            {
                this.Ano = DateTime.Now.Year;
                this.Incremental = valor;
            }
        }

        public int Valor => MontarNumero(this.Ano, this.Incremental);
        private int Incremental { get; set; }
        private int Ano { get; }

        private Protocolo Incrementar()
        {
            return new Protocolo(MontarNumero(this.Ano, ++this.Incremental));
        }

        public static implicit operator int(Protocolo p)
        {
            return MontarNumero(p.Ano, p.Incremental);
        }

        private static int MontarNumero(int ano, int incremental)
        {
            return int.Parse($"{ano}{incremental}");
        }

        public class Gerador
        {
            private int _ano;
            private int _incremental;
            private Protocolo _protocolo;

            public Gerador(int ultimoProtocoloGerado)
            {
                this._protocolo = new Protocolo(ultimoProtocoloGerado);

                this._ano = this._protocolo.Ano;
                this._incremental = this._protocolo.Incremental;
            }

            public Protocolo NovoProtocolo()
            {
                return this._protocolo.Incrementar();
            }
        }
    }
}