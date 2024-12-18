using System.ComponentModel.DataAnnotations;

namespace GranjaGraphQL.Models;

public class Porcino
{
    public int Id { get; set; }
    public string Identificacion { get; set; } = null!;
    public string? Raza { get; set; } 
    public int Edad { get; set; }
    public float Peso { get; set; }

    public int? ClienteId { get; set; } 
    public Cliente? Cliente { get; set; } 
    public ICollection<Alimentacion>? Alimentaciones { get; set; } 
}
