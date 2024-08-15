using CustomSoftMaqueta.Application.User.DTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CustomSoftMaqueta.Application.User.Querys
{
    public class GetUserQuery : IRequest<UserDTO>
    {
        [Required(ErrorMessage = "Ide es un campo obligatorio")]
        public Guid Ide { get; init; }
    }
}
