using Lucilvio.Ticket.Dominio;
using System;

namespace Lucilvio.Ticket.Servicos.ResponderChamado
{
    [Serializable]
    public class NenhumChamadoEncontradoParaResponder : ExcecaoDeNegocio
    {
        public NenhumChamadoEncontradoParaResponder()
        {
        }
    }
}