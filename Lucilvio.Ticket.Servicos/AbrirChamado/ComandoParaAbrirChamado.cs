namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    public class ComandoParaAbrirChamado : IComando
    {
        public ComandoParaAbrirChamado(string cliente, string descricao)
        {
            this.Cliente = cliente;
            this.Descricao = descricao;
        }

        public string Cliente { get; }
        public string Descricao { get; }
    }
}
