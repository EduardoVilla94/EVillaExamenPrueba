using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Persona
    {
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Por favor, ingresa solo letras para el Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Por favor, ingresa solo letras para el Apellido Paterno.")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Por favor, ingresa solo letras para el Apellido Materno.")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "La Dirección es requerida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Sexo es requerido")]
        [RegularExpression(@"^[MF]$", ErrorMessage = "Por favor, ingresa 'M' o 'F' para el Sexo.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El Teléfono es requerido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El Teléfono debe contener exactamente 10 dígitos.")]
        public string Telefono { get; set; }
        public List<Persona>? PersonaList { get; set; }
    }
}
