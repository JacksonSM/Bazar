using Bazar.Domain.Validation;

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

    public Anuncio(string titulo, string descricao, int tempoUso, string cidade, decimal preco)
    {
        Validar(titulo, descricao, tempoUso, cidade ,preco);
        Ativo = true;
    }

    public void Validar(string titulo, string descricao, int tempoUso,
        string cidade, decimal preco)
    {
        DomainExceptionValidation.Quando(string.IsNullOrEmpty(titulo),
        "O campo Titulo é obrigatório");

        DomainExceptionValidation.Quando(string.IsNullOrEmpty(descricao),
        "O campo Descrição é obrigatório");

        DomainExceptionValidation.Quando(string.IsNullOrEmpty(cidade),
        "O campo Cidade é obrigatório");

        DomainExceptionValidation.Quando(preco < 0, "Preço não pode ser negativo.");

        DomainExceptionValidation.Quando(tempoUso < 0, "Tempo de uso não pode ser negativo.");

        Titulo = titulo;
        Descricao = descricao;
        TempoUso = tempoUso;
        Cidade = cidade;
        Preco = preco;
    }
}
