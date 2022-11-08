﻿using Bazar.Application.ViewModel;

namespace Bazar.Application.UseCase.Anuncio.Criar;
public interface ICriarAnuncioUseCase
{
    Task<AnuncioViewModel> ExecuteAsync(AnuncioViewModel model);
}