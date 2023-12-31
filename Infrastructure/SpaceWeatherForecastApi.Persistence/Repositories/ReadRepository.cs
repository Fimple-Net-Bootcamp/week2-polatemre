﻿using SpaceWeatherForecastApi.Application.Repositories;
using SpaceWeatherForecastApi.Domain.Entities.Common;
using SpaceWeatherForecastApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SpaceWeatherForecastApi.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly SpaceWeatherForecastApiDbContext _context;

    public ReadRepository(SpaceWeatherForecastApiDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        var query = Table.Where(expression);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task<T> GetByIdAsync(int id, bool tracking = true)
    //=> await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
    //=> await Table.FindAsync(Guid.Parse(id));
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}
