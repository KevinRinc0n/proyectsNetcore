using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entitites;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Vehiculo, VehiculoDto>().ReverseMap();

        CreateMap<Cliente, ClienteDto>().ReverseMap();

        CreateMap<Empleado, EmpleadoDto>().ReverseMap();
    }
}
