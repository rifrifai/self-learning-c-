namespace API.DTO.Car;

public sealed record class CarDto(
Guid Id,
string Name,
decimal Price,
string Model,
int Year
);
