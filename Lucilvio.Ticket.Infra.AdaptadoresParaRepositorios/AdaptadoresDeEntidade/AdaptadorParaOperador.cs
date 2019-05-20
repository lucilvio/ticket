using Lucilvio.Ticket.Infra.Dados;
using Lucilvio.Ticket.Dominio.Operadores;
using System;

namespace Lucilvio.Ticket.Infra.AdaptadoresParaRepositorios
{
    public static class AdaptadorParaOperador
    {
        public static Operador ParaEntidade(this DadosDoOperador dados)
        {
            if (dados == null)
                return null;

            var tipoDoDestino = typeof(Operador);
            var destino = (Operador)Activator.CreateInstance(tipoDoDestino, true);

            tipoDoDestino.GetProperty("Id").SetValue(destino, dados.Id);
            tipoDoDestino.GetProperty("Nome").SetValue(destino, dados.Nome);
            tipoDoDestino.GetProperty("Email").SetValue(destino, dados.Email);
            tipoDoDestino.GetProperty("Ativo").SetValue(destino, dados.Ativo);
            tipoDoDestino.GetProperty("DataDoCadastro").SetValue(destino, dados.DataDoCadastro);
            tipoDoDestino.GetProperty("Usuario").SetValue(destino, dados.Usuario.ParaEntidade());

            return destino;
        }
    }
}