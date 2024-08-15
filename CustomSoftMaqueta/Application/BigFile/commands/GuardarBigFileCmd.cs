using MediatR;

namespace CustomSoftMaqueta.Application.BigFile.commands
{
    public record GuardarBigFileCmd :IRequest<string>
    {
        public IFormFile File { get; set; }

        public GuardarBigFileCmd(IFormFile file)
        {
            this.File = file;
        }
    }
}
