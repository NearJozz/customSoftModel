using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CustomSoftMaqueta.Application.BigFile.Queries
{
    public class GetUserFileHandler : IRequestHandler<GetUserFileQuery, FileStreamResult>
    {
        private readonly string _fileDirectory;
        public GetUserFileHandler() {
            _fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(_fileDirectory))
            {
                Directory.CreateDirectory(_fileDirectory);
            }
        }
        public async Task<FileStreamResult> Handle(GetUserFileQuery request, CancellationToken cancellationToken)
        {
                var userPath=Path.Combine(_fileDirectory,request.Ide.ToString());
            try {
                if (!Directory.Exists(userPath))
                {
                    throw new Exception("El directorio no existe");
                }
                string[] files = Directory.GetFiles(userPath);
                if (files.Length == 1)
                {
                    string filePath = files[0];
                    string fileName = Path.GetFileName(filePath);
                    string contentType = "application/octet-stream"; // Tipo de contenido por defecto
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                    // Puedes cambiar el tipo de contenido dependiendo del tipo de archivo
                    // Ejemplo: "application/pdf", "image/jpeg", etc.
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                    // Devolver el archivo utilizando FileStreamResult
                    return new FileStreamResult(fileStream, contentType) { FileDownloadName = fileName };
                }
                else
                {
                    throw new Exception("nO EXISTE EL ARCHIVO");
                }
            } 
            catch (Exception ex) {
                throw ex ;
            }
        }
    }
}
