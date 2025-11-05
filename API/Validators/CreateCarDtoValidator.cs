using System;
using API.DTO.Car;
using FluentValidation;

namespace API.Validators;

public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarDtoValidator()
    {
        RuleFor(car => car.Name)
            .NotEmpty().WithMessage("Nama mobil tidak boleh kosong!")
            .MaximumLength(50).WithMessage("Nama mobil tidak boleh lebih dari 50 karakter!");

        RuleFor(car => car.Model)
            .NotEmpty().WithMessage("Model mobil tidak boleh kosong!")
            .MaximumLength(50);

        RuleFor(car => car.Price)
            .GreaterThan(0).WithMessage("Harga harus lebih besar dari 0.");

        RuleFor(car => car.Year)
            .InclusiveBetween(1900, DateTime.Now.Year)
            .WithMessage($"Tahun harus di antara 1900 dan {DateTime.Now.Year}.");
    }
}
