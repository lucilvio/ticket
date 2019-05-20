using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaDadosDoOperador
    {
        public static DadosDoOperador ParaDados(this Operador operador)
        {
            if (operador == null)
                return null;

            return new DadosDoOperador
            {
                Id = operador.Id,
                Nome = operador.Nome,
                Email = operador.Email,
                Ativo = operador.Ativo,
                DataDoCadastro = operador.DataDoCadastro,
                Usuario = operador.Usuario.ParaDados()
            };
        }
    }
}