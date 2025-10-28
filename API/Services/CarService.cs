using System;
using API.DTO.Car;
using API.Model;
using API.Repository;
using AutoMapper;

namespace API.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepo;
    private readonly IMapper _mapper;
    public CarService(ICarRepository carRepo, IMapper mapper)
    {
        _carRepo = carRepo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
    {
        var cars = await _carRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<CarDto?> GetCarByIdAsync(Guid id)
    {
        var car = await _carRepo.GetByIdAsync(id);
        return _mapper.Map<CarDto>(car);
    }
    public async Task<CarDto> CreateCarAsync(CreateCarDto createCarDto)
    {
        var newCar = _mapper.Map<Car>(createCarDto);
        await _carRepo.CreateAsync(newCar);
        return _mapper.Map<CarDto>(newCar);
    }
    public async Task<bool> UpdateCarAsync(Guid id, PatchCarDto patchCarDto)
    {
        var existingCar = await _carRepo.GetByIdAsync(id);
        if (existingCar is null) return false;

        // automapper akan mengupdate properti yang ada di patch ke existingCar
        _mapper.Map(patchCarDto, existingCar);

        // perbarui updatedat secara manual karena tidak ada di DTO
        existingCar.UpdatedAt = DateTime.UtcNow.AddHours(7);
        return await _carRepo.PatchAsync(existingCar);
    }
    public async Task<bool> DeleteCarAsync(Guid id)
    {
        var car = await _carRepo.GetByIdAsync(id);
        if (car is null) return false;
        return await _carRepo.DeleteAsync(car);
    }
}
