using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class MateriaViewModel
    {
        [Key]
        [Required(ErrorMessage = "El código es obligatorio.")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los créditos son obligatorios.")]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10.")]
        public int Creditos { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        public string Carrera { get; set; }
    }
}
