using MediatR;

namespace CustomSoftMaqueta.Application.BigFile.commands
{
    public record  GuardarUsuarioBigFileCmd : IRequest<bool>
    {
        public IFormFile File{get;set;}
        public Guid Ide {get;set;}

        public GuardarUsuarioBigFileCmd(Guid ide,IFormFile file)
        {
            this.Ide=ide;
            this.File=file; 
        }
    }
}
