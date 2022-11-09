namespace Bazar.View.Tools.Upload;

public class UnitOfUpload
{

    private readonly IWebHostEnvironment _webHostEnvironment;

    public UnitOfUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async void CarregarImagem(string path, IFormFile file, string codigo)
    {
        await CarregarImagem(file, codigo, path);
    }

    public async Task CarregarImagem(IFormFile file, string nomeImagem, string path)
    {
        long totalBytes = file.Length;
        string fileName = file.FileName.Trim('"');
        var extension = Path.GetExtension(fileName);
        fileName = nomeImagem + extension;


        fileName = fileName.Contains("\\") ? fileName.Substring(fileName.LastIndexOf("\\") + 1) : fileName;

        byte[] buffer = new byte[1024 * 1024];
        using (FileStream output = File.Create(ObterCaminhoMaisNomeDoArquivo(path, fileName)))
        {
            using (Stream input = file.OpenReadStream())
            {
                int readBytes;
                while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    await output.WriteAsync(buffer, 0, readBytes);
                    totalBytes += readBytes;
                }
            }
        }
    }

    private string ObterCaminhoMaisNomeDoArquivo(string path, string fileName)
    {
        path = _webHostEnvironment.WebRootPath + path;
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        return path + fileName;
    }
}

