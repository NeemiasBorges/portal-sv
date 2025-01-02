using Domain.Entity;
using Infra.Conection;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConnectionContext _context;
        public ClienteRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task Add(Cliente cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();  
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Delete(Cliente cliente)
        {
            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Cliente> Get(int id)
        {
            try
            {
                return await _context.Clientes.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Cliente>> GetAll()
        {
            try
            {
                var listaClientes = await _context.Clientes.ToListAsync();
                return listaClientes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Update(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
