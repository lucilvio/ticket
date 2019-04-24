using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Servicos.InativarOperador
{
    public interface IRepositorioParaInativacaoDoOperador : IRepositorio
    {
        Operador PegarOperadorPeloId(int id);
        void Persistir();
    }
}