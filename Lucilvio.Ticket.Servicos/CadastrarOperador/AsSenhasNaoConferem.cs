using Lucilvio.Ticket.Dominio;
using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Servicos.CadastrarOperador
{
    [Serializable]
    public class AsSenhasNaoConferem : ExcecaoDeNegocio
    {
        public AsSenhasNaoConferem()
        {
        }
    }
}