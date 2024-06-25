using System;
using System.Collections.Generic;

namespace DL;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string? Direccion { get; set; }

    public string Sexo { get; set; } = null!;

    public string? Telefono { get; set; }
}
