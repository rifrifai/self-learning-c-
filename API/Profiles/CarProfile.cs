using System;
using System.Globalization;
using API.DTO.Car;
using API.Model;
using AutoMapper;

namespace API.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString("N0", new CultureInfo("id-ID"))));
        CreateMap<CreateCarDto, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())    //Id, CreatedAt, UpdatedAt akan dibuat otomatis
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        CreateMap<PatchCarDto, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())    //Id, Created akan dibuat otomatis, then Set updatedAt saat patch
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)))
            // untuk setiap properti, gunakan nilai sumber jika tidak null (explicit)
            .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(dest => dest.Model, opt => opt.MapFrom((src, dest) => src.Model ?? dest.Model))
            .ForMember(dest => dest.Price, opt => opt.MapFrom((src, dest) => src.Price ?? dest.Price))
            .ForMember(dest => dest.Year, opt => opt.MapFrom((src, dest) => src.Year ?? dest.Year));
    }
}
