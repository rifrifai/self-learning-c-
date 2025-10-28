using System.ComponentModel.DataAnnotations;

namespace API.DTO.Car;

public sealed record class CreateCarDto(
    [Required]
    [StringLength(50, ErrorMessage = "Name can not be more than 50 characters!")]
    string Name,
    [Required]
    decimal Price,
    [Required]
    string Model,
    [Required]
    int Year
);
