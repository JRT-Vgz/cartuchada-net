using _1_Entities.Product_Entities;
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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name));

            // From Cartdrige to SpotModel
            CreateMap<Cartdrige, SpotModel>()
                .ForMember(dest => dest.SpotDate, opt => opt.MapFrom(src => src.PurchaseDate))
                .ForMember(dest => dest.SpotPrice, opt => opt.MapFrom(src => src.PurchasePrice));
        }
    }
}
