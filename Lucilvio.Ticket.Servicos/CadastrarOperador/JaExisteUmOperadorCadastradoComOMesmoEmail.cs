using Lucilvio.Ticket.Dominio;
using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    [Serializable]
    internal class JaExisteUmOperadorCadastradoComOMesmoEmail : ExcecaoDeNegocio
    {
        public JaExisteUmOperadorCadastradoComOMesmoEmail()
        {
        }
    }
}