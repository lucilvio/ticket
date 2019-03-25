namespace Lucilvio.Ticket.Testes
{
    public class GeradorDeProtocolo
    {
        private int _ano;
        private int _ultimoProtocoloGerado;

        public GeradorDeProtocolo(int ano, int ultimoProtocoloGerado)
        {
            this._ano = ano;
            this._ultimoProtocoloGerado = ultimoProtocoloGerado;
        }

        public string NumeroDoUltimoProcotoloGerado => $"{this._ultimoProtocoloGerado}{this._ano}";

        internal GeradorDeProtocolo NovoProtocolo()
        {
            return new GeradorDeProtocolo(this._ano, ++this._ultimoProtocoloGerado);
        }
    }
}