using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengProg3.Models
{
    public class CalificacionViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        public string MatriculaEstudiante { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una materia.")]
        [ForeignKey("Materia")]
        public int CodigoMateria { get; set; }

        [Required(ErrorMessage = "La nota es obligatoria.")]
        [Range(0, 100, ErrorMessage = "La nota debe estar entre 0 y 100.")]
        public decimal Nota { get; set; }

        [Required(ErrorMessage = "El periodo es obligatorio.")]
        public string Periodo { get; set; }

        // Relación de navegación
        public MateriaViewModel Materia { get; set; }
    }
}

