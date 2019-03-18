namespace Lucilvio.Ticket.Testes
{
    internal class Chamado
    {
        private string _descricao;

        public Chamado(string descricao)
        {
            this._descricao = descricao;

            this.Protocolo = 1;
        }

        public int Protocolo { get; }
    }
}