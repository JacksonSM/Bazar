using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bazar.Application.ViewModel;

public class AnuncioViewModel
{
    public int? Id { get; set; }

    [DisplayName(displayName: "Título")]
    [Required(ErrorMessage = "Campo {0} é requerido.")]
    public string Titulo { get; set; }

    [DisplayName(displayName: "Descrição")]
    [Required(ErrorMessage = "Campo {0} é requerido.")]
    public string Descricao { get; set; }

    [DisplayName(displayName: "Tempo de uso")]
    [Required(ErrorMessage = "Campo {0} é requerido.")]
    public int TempoUso { get; set; }

    [Required(ErrorMessage = "Campo {0} é requerido.")]
    public string Cidade { get; set; }

    [DataType(DataType.Currency)]
    [DisplayName(displayName: "Preço")]
    [Required(ErrorMessage = "Campo {0} é requerido.")]
    public decimal Preco { get; set; }

    public string? ImagemPrincipal { get; set; }
    public string? Imagens { get; set; }

    public string[] ObterImagens()
    {
        return Imagens.Split(",");
    }
}
