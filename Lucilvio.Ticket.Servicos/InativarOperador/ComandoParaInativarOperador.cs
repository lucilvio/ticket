namespace Lucilvio.Ticket.Servicos.InativarOperador
{
    public class ComandoParaInativarOperador : IComando
    {
        public ComandoParaInativarOperador(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
