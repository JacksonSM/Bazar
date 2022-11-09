using Bazar.View.Tools.Upload;

namespace Bazar.View.Tools.Imagens;

public class GerenciadorImagens
{
    private readonly UnitOfUpload _upload;
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly string[] EXTENSAO_PERMITIDOS = { ".jpg", ".jpeg" };
    private const string CAMINHO_IMAGEM = "\\uploads\\imagens_produtos\\";
    private const long LIMITE_MAXIMO_MB = 1000000;

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
        Validar(imagem);
        var nomeImagem = Guid.NewGuid().ToString();
        _upload.CarregarImagem(CAMINHO_IMAGEM, imagem, nomeImagem);
        return nomeImagem + Path.GetExtension(imagem.FileName);
    }

    public List<string> SalvarImagem(IFormFileCollection imagens)
    {
        Validar(imagens);

        var nomesImagens = new List<string>();

        foreach (var imagem in imagens)
        {
            nomesImagens.Add(SalvarImagem(imagem));
        }
        return nomesImagens;
    }

    public string ObterCaminhoImagem(string fileName)
    {
        return Path.Combine(CAMINHO_IMAGEM, fileName);
    }

    private void Validar(IFormFile file)
    {

        if(file.Length > LIMITE_MAXIMO_MB)
            throw new FileLoadException("Tamanho maximo de uma imagem é 1MB.", file.FileName);

        if (!EXTENSAO_PERMITIDOS.Contains(Path.GetExtension(file.FileName)))
                throw new FormatException("Apenas formatos jpeg são permitidos.");
    }

    private void Validar(IFormFileCollection imagens)
    {
        foreach (var fileName in imagens)
        {
            Validar(fileName);
        }
    }

}
