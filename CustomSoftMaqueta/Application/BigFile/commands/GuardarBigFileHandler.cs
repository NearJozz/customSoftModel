using MediatR;

namespace CustomSoftMaqueta.Application.BigFile.commands
{
    public class GuardarBigFileHandler : IRequestHandler<GuardarBigFileCmd, string>
    {
        private readonly string _fileDirectory;
        public GuardarBigFileHandler()
        {
            _fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(_fileDirectory))
            {
                Directory.CreateDirectory(_fileDirectory);
            }
        }
        public async Task<string> Handle(GuardarBigFileCmd request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
            {
                throw new Exception("Invalid file.");
            }

            var fileName = Path.GetFileName(request.File.FileName);
            var filePath = Path.Combine(_fileDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream, cancellationToken);
            }

            return filePath;
        }
    }
}
