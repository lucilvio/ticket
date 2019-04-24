namespace Lucilvio.Ticket.Servicos.Comum.ServicosExternos.Transacao
{
    public interface IServicoDeTransacao
    {
        void Desfazer();
        void Comitar();
        void Abrir();
    }
}
