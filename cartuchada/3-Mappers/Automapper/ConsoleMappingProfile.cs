
using _1_Entities;
using _3_Data.Models;
using _3_Mappers.DTOs;
using _3_Mappers.DTOs.Purchase_Dtos;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class ConsoleMappingProfile : Profile
    {
        public ConsoleMappingProfile() 
        {
            // From ConsoleModel to VideoConsole
            CreateMap<ConsoleModel, VideoConsole>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference.Name));

            // From VideoConsole to ConsoleModel
            CreateMap<VideoConsole, ConsoleModel>()
                .ForMember(dest => dest.Reference, map => map.Ignore());

            // From ConsolePurchaseDto to VideoConsole
            CreateMap<ConsolePurchaseDto, VideoConsole>();
        }
    }
}
