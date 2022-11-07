namespace Bazar.Domain.Entities;
public class Anuncio : BaseEntity
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public int TempoUso { get; private set; }
    public string Cidade { get; private set; }
    public decimal Preco { get; private set; }
    public bool Ativo { get; private set; }

    public string Imagens { get; private set; } 


    public Anuncio(){}//Para EF

    public Anuncio(string titulo, string descricao, int tempoUso,
        string cidade, decimal preco)
    {
        Titulo = titulo;
        Descricao = descricao;
        TempoUso = tempoUso;
        Cidade = cidade;
        Preco = preco;
        Ativo = true;
    }
}
