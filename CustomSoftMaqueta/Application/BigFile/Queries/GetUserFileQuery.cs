using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomSoftMaqueta.Application.BigFile.Queries
{
    public record GetUserFileQuery :IRequest<FileStreamResult>
    {
        [Required(ErrorMessage ="Se Require identificador de usuario")]
        public Guid Ide { get; set; }

        public GetUserFileQuery(Guid Ide) { 
            this.Ide = Ide;
        }
    }
}
