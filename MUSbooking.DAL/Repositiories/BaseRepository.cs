﻿using Fontech.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using MUSbooking.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fontech.DAL.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
      if (entity == null)
        {
            throw new ArgumentNullException("Entity is null");
        }
        await _context.AddAsync(entity);

        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public TEntity Update (TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity is null");
        _context.Update(entity);

        return entity;
    }

    void IBaseRepository<TEntity>.Remove(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Entity is null");
        _context.Remove(entity);
    }
}
