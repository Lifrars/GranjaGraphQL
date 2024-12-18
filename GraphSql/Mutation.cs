using GranjaGraphQL.Data;
using GranjaGraphQL.Models;
using HotChocolate;

namespace GranjaGraphQL.GraphSql
{
    public class Mutation
    {
 
        public async Task<Cliente> CreateCliente([Service] ApplicationDbContext context, Cliente input)
        {
            context.Clientes.Add(input);
            await context.SaveChangesAsync();
            return input;
        }


        public async Task<Porcino> CreatePorcino([Service] ApplicationDbContext context, Porcino input)
        {
            context.Porcinos.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<Alimentacion> CreateAlimentacion([Service] ApplicationDbContext context, Alimentacion input)
        {
            context.Alimentaciones.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<Cliente> UpdateCliente([Service] ApplicationDbContext context, int id, Cliente input)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                cliente.Nombres = input.Nombres;
                cliente.Direccion = input.Direccion;
                await context.SaveChangesAsync();
            }
            return cliente;
        }
        
        
        public async Task<Porcino> UpdatePorcino([Service] ApplicationDbContext context, int id, Porcino input)
        {
            var porcino = await context.Porcinos.FindAsync(id);
            if (porcino != null)
            {
                porcino.Identificacion = input.Identificacion;
                await context.SaveChangesAsync();
            }
            return porcino;
        }

    
        public async Task<Alimentacion> UpdateAlimentacion([Service] ApplicationDbContext context, int id, Alimentacion input)
        {
            var alimentacion = await context.Alimentaciones.FindAsync(id);
            if (alimentacion != null)
            {
                alimentacion.Detalles = input.Detalles;
                await context.SaveChangesAsync();
            }
            return alimentacion;
        }

        public async Task<bool> DeleteCliente([Service] ApplicationDbContext context, int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePorcino([Service] ApplicationDbContext context, int id)
        {
            var porcino = await context.Porcinos.FindAsync(id);
            if (porcino != null)
            {
                context.Porcinos.Remove(porcino);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        
        public async Task<bool> DeleteAlimentacion([Service] ApplicationDbContext context, int id)
        {
            var alimentacion = await context.Alimentaciones.FindAsync(id);
            if (alimentacion != null)
            {
                context.Alimentaciones.Remove(alimentacion);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
