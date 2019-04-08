using Lucilvio.Ticket.Dominio;
using System;
using System.Runtime.Serialization;

namespace Lucilvio.Ticket.Servicos.AbrirChamado
{
    [Serializable]
    internal class NenhumClienteEncontradoParaFazerAAberturaDoChamado : ExcecaoDeNegocio
    {
    }
}