using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    public interface IRepositorioParaCadastroDeOperador
    {
        void AdicionarOperador(Operador operador);
        void Persistir();
    }
}