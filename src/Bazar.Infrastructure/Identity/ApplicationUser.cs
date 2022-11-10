using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bazar.Infrastructure.Identity;


public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Display(Name = "Nome Completo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [StringLength(maximumLength: 80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres!", MinimumLength = 2)]
    public string NomeCompleto { get; set; }
}

