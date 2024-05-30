
using Microsoft.EntityFrameworkCore.Storage;
using MUSbooking.Domain.Intarfaces.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fontech.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> : IStateSaveChanges
{
    IQueryable<TEntity> GetAll();

    Task<TEntity> CreateAsync(TEntity entity);

    TEntity Update(TEntity entity);
    void Remove(TEntity entity);
}
