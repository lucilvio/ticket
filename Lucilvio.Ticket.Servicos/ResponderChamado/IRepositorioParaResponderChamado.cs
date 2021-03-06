﻿using Lucilvio.Ticket.Dominio.Chamados;
using Lucilvio.Ticket.Dominio.Operadores;

namespace Lucilvio.Ticket.Servicos.ResponderChamado
{
    public interface IRepositorioParaResponderChamado : IRepositorio
    {
        Operador PegarOperadorPeloLogin(string   operador);
        Chamado PegarChamadoPeloProtocolo(int chamado);
        void Persistir();
    }
}