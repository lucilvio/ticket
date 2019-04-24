using Lucilvio.Ticket.Dominio;
using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Servicos.EntrarNoSistema
{
    [Serializable]
    internal class UsuarioInativo : ExcecaoDeNegocio
    {
        public UsuarioInativo()
        {
        }
    }
}