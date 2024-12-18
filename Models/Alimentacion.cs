using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranjaGraphQL.Models;

public class Alimentacion
{
    [Key]
    public int Id { get; set; }
    
    public int PorcinoId { get; set; }

    [ForeignKey(nameof(PorcinoId))]
    public Porcino? Porcino { get; set; } = null!; 

    public string Detalles { get; set; } = string.Empty; 
}