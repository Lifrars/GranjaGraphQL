using GranjaGraphQL.Data;
using GranjaGraphQL.Models;
using HotChocolate;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GranjaGraphQL.GraphSql
{
    public class Query
    {

        public IQueryable<Cliente> GetClientes([Service] ApplicationDbContext context) =>
            context.Clientes;
        
        public IQueryable<Porcino> GetPorcinos([Service] ApplicationDbContext context) =>
            context.Porcinos;
        
        public IQueryable<Porcino> GetPorcinosResolvers([Service] ApplicationDbContext context) =>
            context.Porcinos.Where(p => p.Cliente != null)
                .Include(p => p.Cliente)
                .Include(p => p.Alimentaciones);

  
        public IQueryable<Alimentacion> GetAlimentaciones([Service] ApplicationDbContext context) =>
            context.Alimentaciones;

  
        public Cliente GetClienteById([Service] ApplicationDbContext context, int id) =>
            context.Clientes.FirstOrDefault(c => c.Id == id);

        public Porcino GetPorcinoById([Service] ApplicationDbContext context, int id) =>
            context.Porcinos.FirstOrDefault(p => p.Id == id);


        public Alimentacion GetAlimentacionById([Service] ApplicationDbContext context, int id) =>
            context.Alimentaciones
                .Where(a => a.Id == id)
                .Include(a => a.Porcino)  
                .FirstOrDefault();



        public IQueryable<Porcino> GetPorcinosByClienteId([Service] ApplicationDbContext context, int clienteId) =>
            context.Porcinos.Where(p => p.ClienteId == clienteId);


        public IQueryable<Alimentacion> GetAlimentacionesByPorcinoId([Service] ApplicationDbContext context, int porcinoId) =>
            context.Alimentaciones.Where(a => a.PorcinoId == porcinoId);
    }
}
