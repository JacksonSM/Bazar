namespace Bazar.Domain.Entities;
public class Anuncio : BaseEntity
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int TempoUso { get; set; }
    public string Cidade { get; set; }
    public decimal Preco { get; set; }
    public bool Ativo { get; set; }

    public List<string> Imagens { get; set; }

    public Anuncio(string titulo, string descricao, int tempoUso,
        string cidade, decimal preco, List<string> imagens)
    {
        Titulo = titulo;
        Descricao = descricao;
        TempoUso = tempoUso;
        Cidade = cidade;
        Preco = preco;
        Imagens = imagens;
        Ativo = true;
    }
}
