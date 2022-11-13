﻿using AutoMapper;
using Bazar.Application.ViewModel;
using Bazar.Domain.Entities;

namespace Bazar.Application.Tools.Mappings;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        EntidadeParaViewModel();
    }

    private void EntidadeParaViewModel()
    {
        CreateMap<Anuncio, AnuncioViewModel>();
    }
}
