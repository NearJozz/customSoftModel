using System.ComponentModel.DataAnnotations;

namespace CustomSoftMaqueta.Application.User.DTO
{
    public class UserUpdateDTO
    {
        

            [StringLength(20, ErrorMessage = "El nombre no puede exceder los 20 caracteres.")]
            public string? Name { get; set; }

            
            [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
            public string? Email { get; set; }

            
            [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
            public string? Password { get; set; }


       
    }
}
