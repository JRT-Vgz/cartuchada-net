using _1_Domain.Product_Entities;
using _3_Data.Models;
using _3_Mappers.DTOs.Purchase_Dtos;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class CartdrigeMappingProfile : Profile
    {
        public CartdrigeMappingProfile()
        {
            // From CartdrigeModel to Cartdrige
            CreateMap<CartdrigeModel, Cartdrige>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Game.ProductType.Name))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference.Name));

            // From Cartdrige to CartdrigeModel
            CreateMap<Cartdrige, CartdrigeModel>()
                .ForMember(dest => dest.ProductType, map => map.Ignore())
                .ForMember(dest => dest.Region, map => map.Ignore())
                .ForMember(dest => dest.Condition, map => map.Ignore())
                .ForMember(dest => dest.Reference, map => map.Ignore());

            // From CartdrigePurchaseDto to Cartdrige
            CreateMap<CartdrigePurchaseDto, Cartdrige>();
        }
    }
}
