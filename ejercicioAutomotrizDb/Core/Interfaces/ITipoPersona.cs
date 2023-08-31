using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entitites;

namespace Core.Interfaces;

public interface ITipoPersona : IGenericRepo<TipoPersona>
{
    Task SaveAsync();
}