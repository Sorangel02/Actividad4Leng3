using System.ComponentModel.DataAnnotations;

namespace Actividad4Prog3.Models
{
    public class Estudiante
    {
        [Key]
        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una carrera.")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un turno.")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de ingreso.")]
        public string TipoIngreso { get; set; }
      

        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos y condiciones.")]
        public bool TerminosYCondiciones { get; set; }
    }
}
