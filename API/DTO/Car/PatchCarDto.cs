namespace API.DTO.Car;

public sealed record class PatchCarDto(
string? Name,
decimal? Price,
string? Model,
int? Year
);
