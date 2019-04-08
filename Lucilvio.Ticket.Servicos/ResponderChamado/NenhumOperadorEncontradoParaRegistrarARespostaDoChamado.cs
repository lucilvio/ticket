using Lucilvio.Ticket.Dominio;
using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Servicos.ResponderChamado
{
    [Serializable]
    public class NenhumOperadorEncontradoParaRegistrarARespostaDoChamado : ExcecaoDeNegocio
    {
    }
}