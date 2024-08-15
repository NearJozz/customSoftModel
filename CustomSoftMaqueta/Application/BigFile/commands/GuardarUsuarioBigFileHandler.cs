using MediatR;

namespace CustomSoftMaqueta.Application.BigFile.commands
{
    public class GuardarUsuarioBigFileHandler : IRequestHandler<GuardarUsuarioBigFileCmd, bool>
    {
        private readonly string _fileDirectory;
        public GuardarUsuarioBigFileHandler()
        {
            _fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(_fileDirectory))
            {
                Directory.CreateDirectory(_fileDirectory);
            }
        }
        public async Task<bool> Handle(GuardarUsuarioBigFileCmd request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
            {
                throw new Exception("Invalid file.");
            }
            var userPath = Path.Combine(_fileDirectory, request.Ide.ToString());
            try
            {
                if (!Directory.Exists(userPath))
                {
                    Directory.CreateDirectory(userPath);
                }
            }
            catch (Exception ex) {
                throw new Exception("Error Al crear el directorio para el usuario");
            }
            var fileName = Path.GetFileName(request.File.FileName);
            var filePath = Path.Combine(userPath, fileName);
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream, cancellationToken);
                }
            }
            catch (Exception ex) {
                throw ex;
            }

            return true;
        }
    }
}
