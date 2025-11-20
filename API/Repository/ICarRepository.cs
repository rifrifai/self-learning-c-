using System;
using API.DTO;
using API.DTO.Car;
using API.Model;

namespace API.Repository;

public interface ICarRepository : IRepository<Car>
{
    Task<PagedResult<Car>> GetAllAsync(
        int pageNumber = 1,
        int pageSize = 10,
        string? sortBy = null,
        string? sortOrder = null,
        string? searchQuery = null
    );
    Task<CarDto?> GetCarByIdAsync(Guid id);
    Task<CarDto> CreateCarAsync(CreateCarDto createCarDto);
    Task<CarDto?> UpdateCarAsync(Guid id, PatchCarDto patchCarDto);
    Task<bool> DeleteCarAsync(Guid id);
}
