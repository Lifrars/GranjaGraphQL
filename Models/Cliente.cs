using System.ComponentModel.DataAnnotations;

namespace GranjaGraphQL.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; } 

    public string Cedula { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;

    public ICollection<Porcino>? Porcinos { get; set; } = new List<Porcino>();
}