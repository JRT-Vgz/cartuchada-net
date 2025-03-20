
using _1_Entities.Product_Entities;
using _1_Entities.Sold_Product_Entities;
using _3_Data.Models.SaleModels;
using AutoMapper;

namespace _3_Mappers.Automapper
{
    public class SoldCartdrigeMappingProfile : Profile
    {
        public SoldCartdrigeMappingProfile()
        {
            // From SoldCartdrigeModel to SoldCartdrige
            CreateMap<SoldCartdrigeModel, SoldCartdrige>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name));

            // From SoldCartdrige to SoldCartdrigeModel
            CreateMap<Cartdrige, SoldCartdrigeModel>();

            // From CartdrigePurchaseDto to Cartdrige
            //CreateMap<CartdrigePurchaseDto, Cartdrige>();

            //From Cartdrige to SoldCartdrige
            CreateMap<Cartdrige, SoldCartdrige>()
                .ForMember(dest => dest.Id, map => map.Ignore());
        }
    }
}
