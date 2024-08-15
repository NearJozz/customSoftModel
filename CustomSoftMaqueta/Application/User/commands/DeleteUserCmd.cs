using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CustomSoftMaqueta.Application.User.commands
{
    public record DeleteUserCmd : IRequest<bool>
    {
        [Required(ErrorMessage ="El campo Ide es obligatorio")]
        public Guid Ide {  get; set; }
    }
}
