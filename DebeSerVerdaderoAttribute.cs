using System.ComponentModel.DataAnnotations;

namespace Actividad4Prog3.Models
{
    public class DebeSerVerdaderoAttribute : ValidationAttribute
    {
        public DebeSerVerdaderoAttribute()
        {
            ErrorMessage = "Debes aceptar los términos.";
        }

        public override bool IsValid(object? value)
        {
            return value is bool boolean && boolean;
        }

    }
}


