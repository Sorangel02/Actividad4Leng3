using System;
using System.Collections.Generic;

namespace Actividad4Prog3.Models;

public partial class Materia
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
