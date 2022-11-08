using Bazar.View.Tools.Upload;

namespace Bazar.View.Tools.Imagens;

public class GerenciadorImagens
{
    private readonly string[] EXTENSAO_PERMITIDOS = { ".jpeg" };
    private readonly UnitOfUpload _upload;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public GerenciadorImagens(UnitOfUpload upload, IWebHostEnvironment webHostEnvironment)
    {
        _upload = upload;
        _webHostEnvironment = webHostEnvironment;
    }

    public void ExcluirImagem(string nomeImagem)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath + $"\\uploads\\imagens_produtos\\{nomeImagem}");
        File.Delete(path);
    }

    public void ExcluirImagem(string[] listaNomes)
    {
        foreach (var nomeImagem in listaNomes)
        {
            ExcluirImagem(nomeImagem);
        }
    }

    public string SalvarImagem(IFormFile imagem)
    {
        Validar(imagem.FileName);
        var nomeImagem = Guid.NewGuid().ToString();
        _upload.CarregarImagem(imagem, nomeImagem);
        return nomeImagem + Path.GetExtension(imagem.FileName);
    }

    public List<string> SalvarImagem(IFormFileCollection imagens)
    {
        Validar(imagens.Select(c => c.FileName).ToArray());

        var nomesImagens = new List<string>();

        foreach (var imagem in imagens)
        {
            nomesImagens.Add(SalvarImagem(imagem));
        }
        return nomesImagens;
    }

    private void Validar(string fileName)
    {
        if (!EXTENSAO_PERMITIDOS.Contains(Path.GetExtension(fileName)))
                throw new FormatException("Apenas formatos jpeg são permitidos.");
    }

    private void Validar(string[] fileNames)
    {
        foreach (var fileName in fileNames)
        {
            Validar(fileName);
        }
    }

}
