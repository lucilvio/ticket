using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Servicos.AtivarOperador
{
    public interface IRepositorioParaAtivacaoDoOperador : IRepositorio 
    {
        Operador PegarOperadorPeloId(int id);
        void Persistir(Operador operador);
    }
}