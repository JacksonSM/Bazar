namespace Bazar.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    { }

    public static void Quando(bool temErro, string mensagemErro)
    {
        if (temErro)
            throw new DomainExceptionValidation(mensagemErro);
    }
}
