namespace Bazar.Application.Response;

public class Paginacao
{
    public int TotalAnuncio { get; set; }
    public int ItensPorPagina { get; set; }
    public int PaginaAtual { get; set; }
    public int TotalPaginas { get; set; }
}