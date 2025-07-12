using System;
using System.Collections.Generic;

namespace Actividad4Prog3.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    public string MatriculaEstudiante { get; set; } = null!;

    public int CodigoMateria { get; set; }

    public double Nota { get; set; }

    public string Periodo { get; set; } = null!;

    public virtual Materia CodigoMateriaNavigation { get; set; } = null!;
}
