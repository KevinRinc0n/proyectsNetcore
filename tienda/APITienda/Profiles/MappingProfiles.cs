using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITienda.Dtos;
using AutoMapper;
using Core.Entities;
using API.Dtos;

namespace APITienda.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pais, PaisDto>().ReverseMap();

        CreateMap<Pais, PaisesDto>().ReverseMap();

        CreateMap<Estado, EstadoDto>().ReverseMap();
    }
}
