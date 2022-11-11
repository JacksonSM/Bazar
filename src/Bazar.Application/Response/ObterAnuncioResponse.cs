using Bazar.Application.ViewModel;

namespace Bazar.Application.Response;
public class ObterAnuncioResponse
{
    public IEnumerable<AnuncioViewModel> anunciosVM { get; set; }
    public Paginacao Paginacao { get; set; }
}
