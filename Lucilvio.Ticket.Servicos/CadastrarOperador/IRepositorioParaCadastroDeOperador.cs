using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    public interface IRepositorioParaCadastroDeOperador : IRepositorio
    {
        void AdicionarOperador(Operador operador);
        void Persistir();
        Operador PegarOperadorPorEmail(string email);
    }
}