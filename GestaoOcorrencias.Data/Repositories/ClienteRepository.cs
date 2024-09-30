using GestaoOcorrencias.Data.Interfaces;
using GestaoOcorrencias.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationContext _context;

        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            try
            {                                                                                                                               
                var clientes = await _context.Clientes.AsNoTracking().ToListAsync();                
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
            try
            {
                _context.Clientes.Add(obj);

                if (!_context.Commit())
                {
                    throw new Exception("Erro ao incluir o cliente.");
                }

                return obj; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir o cliente: " + ex.Message);
            }
        }

        public async Task<Cliente> Update(int id, Cliente obj)
        {
            try
            {
                var clienteExistente = await _context.Clientes.FindAsync(id);
                if (clienteExistente == null)
                {
                    throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
                }

                clienteExistente.Nome = obj.Nome;
                clienteExistente.Endereco = obj.Endereco;
                clienteExistente.Telefone = obj.Telefone;
                clienteExistente.Email = obj.Email;

                if (!_context.Commit())
                {
                    throw new Exception("Erro ao atualizar o cliente.");
                }

                return clienteExistente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o cliente: " + ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var clienteExistente = await _context.Clientes.FindAsync(id);

                _context.Clientes.Remove(clienteExistente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
