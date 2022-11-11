namespace Bazar.Application.Request;
public class AnuncioQuery
{
    public string? Titulo { get; set; }
    public string? Cidade { get; set; }
    public int? PaginaAtual { get; set; }
    public int? ItensPorPagina { get; set; }
}
