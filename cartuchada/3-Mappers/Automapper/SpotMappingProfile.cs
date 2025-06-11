using _1_Domain.Product_Entities;
using _3_Data.Models.Product_Models;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class SpotMappingProfile : Profile
    {
        public SpotMappingProfile()
        {
            // From SpotModel to Cartdrige
            CreateMap<SpotModel, Cartdrige>()
                .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.SpotDate))
                .ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.SpotPrice))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name));

            // From Cartdrige to SpotModel
            CreateMap<Cartdrige, SpotModel>()
                .ForMember(dest => dest.ProductType, map => map.Ignore())
                .ForMember(dest => dest.Region, map => map.Ignore())
                .ForMember(dest => dest.Condition, map => map.Ignore())
                .ForMember(dest => dest.SpotDate, opt => opt.MapFrom(src => src.PurchaseDate))
                .ForMember(dest => dest.SpotPrice, opt => opt.MapFrom(src => src.PurchasePrice));
        }
    }
}
