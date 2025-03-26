
using _1_Domain.Product_Entities;
using _1_Domain.Sold_Product_Entities;
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
            CreateMap<SoldCartdrige, SoldCartdrigeModel>();

            //From Cartdrige to SoldCartdrige
            CreateMap<Cartdrige, SoldCartdrige>()
                .ForMember(dest => dest.IdCartdrige, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, map => map.Ignore());

            //From SoldCartdrige to Cartdrige
            CreateMap<SoldCartdrige, Cartdrige>()
                .ForMember(dest => dest.Id, map => map.Ignore());
        }
    }
}
