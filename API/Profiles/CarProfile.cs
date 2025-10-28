using System;
using API.DTO.Car;
using API.Model;
using AutoMapper;

namespace API.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CreateCarDto, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())    //Id, CreatedAt, UpdatedAt akan dibuat otomatis
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        CreateMap<PatchCarDto, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())    //Id, Created akan dibuat otomatis, then Set updatedAt saat patch
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(7)));
    }
}
