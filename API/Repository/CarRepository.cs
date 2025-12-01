using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.DTO.Car;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;
public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PagedResult<Car>> GetAllAsync(int pageNumber, int pageSize, string? sortBy, string? sortOrder, string? searchQuery)
    {
        var query = _dbSet.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(c => c.Name.Contains(searchQuery) || c.Model.Contains(searchQuery));
        }

        Expression<Func<Car, object>> keySelector = sortBy?.ToLower() switch
        {
            "name" => Car => Car.Name,
            "model" => Car => Car.Model,
            "year" => Car => Car.Year,
            _ => Car => Car.Id
        };

        if(sortOrder?.ToLower() == "desc") query = query.OrderByDescending(keySelector);
        else query = query.OrderBy(keySelector);

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<Car>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public Task<CarDto?> GetCarByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CarDto> CreateCarAsync(CreateCarDto createCarDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCarAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CarDto?> UpdateCarAsync(Guid id, PatchCarDto patchCarDto)
    {
        throw new NotImplementedException();
    }
}