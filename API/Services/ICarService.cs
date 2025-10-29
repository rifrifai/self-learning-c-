using System;
using API.DTO.Car;

namespace API.Services;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllCarsAsync();
    Task<CarDto?> GetCarByIdAsync(Guid id);
    Task<CarDto> CreateCarAsync(CreateCarDto createCarDto);
    Task<CarDto?> UpdateCarAsync(Guid id, PatchCarDto patchCarDto);
    Task<bool> DeleteCarAsync(Guid id);
}
