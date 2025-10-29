using System;
using API.DTO.Car;
using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car is null) return NotFound();

        return Ok(car);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody] CreateCarDto createCarDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newCar = await _carService.CreateCarAsync(createCarDto);
        var result = CreatedAtAction(nameof(GetCar), new { id = newCar.Id }, newCar);
        return result;
    }
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateCar(Guid id, [FromBody] PatchCarDto patchCarDto)
    {
        var updatedCar = await _carService.UpdateCarAsync(id, patchCarDto);
        if (updatedCar is null) return NotFound();

        return Ok(updatedCar);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        var result = await _carService.DeleteCarAsync(id);
        if (!result) return NotFound();

        return Ok(result);
    }
}
