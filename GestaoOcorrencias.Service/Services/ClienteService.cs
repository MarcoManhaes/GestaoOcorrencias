using GestaoOcorrencias.Data.Interfaces;
using GestaoOcorrencias.Data.Models;
using GestaoOcorrencias.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepositorio;

        public ClienteService(IClienteRepository clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            try
            {
                var clientes = await _clienteRepositorio.GetAll();
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<Cliente> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> Create(Cliente obj)
        {
            return await _clienteRepositorio.Create(obj);
        }

        public async Task<Cliente> Update(int id, Cliente obj)
        {
            return await _clienteRepositorio.Update(id, obj);
        }

        public async Task Delete(int id)
        {
            await _clienteRepositorio.Delete(id);
        }
    }
}
