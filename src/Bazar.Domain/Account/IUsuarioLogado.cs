namespace Bazar.Domain.Account;
public interface IUsuarioLogado
{
    bool IsAutenticado();
    string ObterUsuarioId();
    Task<string> ObterUsuarioNomeCompletoAsync();
}
