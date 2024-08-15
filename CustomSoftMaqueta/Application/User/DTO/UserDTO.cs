using System.ComponentModel.DataAnnotations;

namespace CustomSoftMaqueta.Application.User.DTO
{
    public class UserDTO
    {
            [Required(ErrorMessage = "El Ide es obligatorio.")]
            public Guid Ide { get; set; }

            [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
            [StringLength(20, ErrorMessage = "El nombre no puede exceder los 20 caracteres.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
            [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "La contraseña es obligatoria.")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
            public string Password { get; set; }


       
    }
}
