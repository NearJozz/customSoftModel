using CustomSoftMaqueta.Application.User.DTO;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CustomSoftMaqueta.Application.User.commands
{
    public record UpdateUserCmd : IRequest<UserCleanDTO>
    {
        [Required(ErrorMessage ="Ide es un campo obligatorio")]
        public Guid Ide { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }

    }
}
