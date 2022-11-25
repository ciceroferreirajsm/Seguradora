﻿using Seguradora.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Intefaces
{
    public interface IClienteService
    {
        Task<Cliente> AdicionarCliente(Cliente cliente);

        Task<Cliente> ObterPorId(int idCLiente);

        Task<List<Cliente>> ObterTodosClientes();

        Task<bool> ExcluirCliente(int idCLiente);

        Task<Cliente> AtualizarCliente(Cliente cLiente);

        Task<bool> LogarUsuario(Usuario usuario);
    }
}
