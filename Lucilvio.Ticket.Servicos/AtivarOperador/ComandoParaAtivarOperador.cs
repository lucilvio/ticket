namespace Lucilvio.Ticket.Servicos.AtivarOperador
{
    public class ComandoParaAtivarOperador : IComando
    {
        public ComandoParaAtivarOperador(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
