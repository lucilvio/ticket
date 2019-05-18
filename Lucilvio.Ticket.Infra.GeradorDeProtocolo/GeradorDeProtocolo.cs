using System;
using Lucilvio.Ticket.Servicos.AbrirChamado;

namespace Lucilvio.Ticket.Infra.GeradorDeProtocolo
{
    public class GeradorDeProtocolo : IGeradorDeProtocolo
    {
        public int Gerar(int ultimoProtocoloDeChamadoCriado)
        {
            if (ultimoProtocoloDeChamadoCriado != 0 && ultimoProtocoloDeChamadoCriado.ToString().Length < 5)
                throw new InvalidOperationException("O protolo informado não foi gerado por esse gerador");

            var anoCorrente = DateTime.Now.Year;

            if (ultimoProtocoloDeChamadoCriado == 0)
                return this.MontarProtocolo(anoCorrente, 0);

            var ano = int.Parse(ultimoProtocoloDeChamadoCriado.ToString().Substring(0, 4));
            var incremental = int.Parse(ultimoProtocoloDeChamadoCriado.ToString().Substring(4));

            if (ano < anoCorrente)
            {
                ano = anoCorrente;
                incremental = 0;
            }

            return this.MontarProtocolo(ano, incremental);
        }

        private int MontarProtocolo(int ano, int incremental)
        {
            return int.Parse($"{ano}{++incremental}");
        }
    }
}
