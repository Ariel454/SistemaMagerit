using SeguridadInformática.Enums;
using System.ComponentModel.DataAnnotations;
namespace SeguridadInformática.Models;
public class Activo
{
    [Key]
    public string Id_Activo { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public TipoDeActivo TipoActivo { get; set; }

    [Required]
    public TagsType TipoTag {  get; set; }
    public string TagActivo { get; set; } // Relación con Tag


    [Required]
    public ValoracionCorta Confidencialidad { get; set; }

    [Required]
    public ValoracionIntegridad Integridad { get; set; }

    [Required]
    public ValoracionLarga Disponibilidad { get; set; }

    //public virtual ICollection<RiesgoPorActivo>? RiesgosPorActivo { get; set; }

    public float CalcularValoracion()
    {
        float total = 0;

        if (Disponibilidad == ValoracionLarga.DB)
        {
            total += 0.83f;
        }
        else if (Disponibilidad == ValoracionLarga.DM)
        {
            total += 1.25f;
        }
        else if (Disponibilidad == ValoracionLarga.DA)
        {
            total += 1.66f;
        }

        if (Integridad == ValoracionIntegridad.IB)
        {
            total += 0.83f;
        }
        else if (Integridad == ValoracionIntegridad.IM)
        {
            total += 1.25f;
        }
        else if (Integridad == ValoracionIntegridad.IA)
        {
            total += 1.66f;
        }

        if (Confidencialidad == ValoracionCorta.IPB)
        {
            total += 0.83f;
        }
        else if (Confidencialidad == ValoracionCorta.IPC)
        {
            total += 1.25f;
        }
        else if (Confidencialidad == ValoracionCorta.IPR)
        {
            total += 1.66f;
        }

        return total >= 4.98 ? 5 : total;
    }
}