
using _1_Entities;
using _3_Data.Models;
using _3_Mappers.DTOs;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class CartdrigeMappingProfile : Profile
    {
        public CartdrigeMappingProfile() 
        {
            // From CartdrigeModel to Cartdrige
            CreateMap<CartdrigeModel, Cartdrige>()
                //.ForMember(dest => dest.IdReference, opt => opt.MapFrom(src => src.IdReference))
                //.ForMember(dest => dest.IdProductType, opt => opt.MapFrom(src => src.IdProductType))
                //.ForMember(dest => dest.IdGame, opt => opt.MapFrom(src => src.IdGame))
                ////.ForMember(dest => dest.IdSystem, opt => opt.MapFrom(src => src.Game.IdSystem))
                //.ForMember(dest => dest.IdRegion, opt => opt.MapFrom(src => src.IdRegion))
                //.ForMember(dest => dest.IdCondition, opt => opt.MapFrom(src => src.IdCondition))
                //.ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate))
                //.ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.PurchasePrice))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference.Name));

            // From Cartdrige to CartdrigeModel
            CreateMap<Cartdrige, CartdrigeModel>()
                .ForMember(dest => dest.Reference, map => map.Ignore());

            // From CartdrigePurchaseDto to Cartdrige
            CreateMap<CartdrigePurchaseDto, Cartdrige>();
        }
    }
}
