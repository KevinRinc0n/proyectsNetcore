using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entitites;

namespace Core.Interfaces;

public interface ICliente : IGenericRepo<Cliente>
{
    Task SaveAsync();
}